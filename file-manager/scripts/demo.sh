#!/usr/bin/env bash
set -euo pipefail
repo_dir="$(cd "$(dirname "$0")/.." && pwd)"
demo_dir="$(mktemp -d /tmp/file-manager-demo.XXXXXX)"
trap 'rm -rf -- "$demo_dir"' EXIT
mkdir "$demo_dir/docs" "$demo_dir/archive"
printf 'Hello from File Manager!\n' > "$demo_dir/docs/hello.txt"
printf '%s\n' \
  "connect $demo_dir" \
  'tree list -d 2' \
  'tree goto docs' \
  'file show hello.txt -m console' \
  'file rename hello.txt greeting.txt' \
  'file move greeting.txt /archive/greeting.txt' \
  'tree goto /archive' \
  'file show greeting.txt -m console' \
  'file delete greeting.txt' \
  'disconnect' | dotnet run \
    --project "$repo_dir/src/Lab4.Presentation/Lab4.Presentation.csproj" \
    -c Release --no-build

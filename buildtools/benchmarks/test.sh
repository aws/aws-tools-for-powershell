#!/bin/bash
# Performance test runner (Linux). Runs from the artifact root; prints only the
# results JSON to stdout (the framework does: ./test.sh <args> > output.json).
set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"

# Invoke-Benchmarks.ps1 writes JSON to stdout and progress to stderr.
pwsh -NoProfile -NonInteractive -File "$SCRIPT_DIR/benchmarks/Invoke-Benchmarks.ps1" -Runtime LinuxPwsh "$@"

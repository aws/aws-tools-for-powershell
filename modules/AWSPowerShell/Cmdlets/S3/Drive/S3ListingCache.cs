/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// A listed child of a prefix: a folder (CommonPrefix) or a file (S3Object), already
    /// projected into the uniform S3ItemInfo the provider emits. Shared by the provider's
    /// listing methods and the listing cache.
    /// </summary>
    internal sealed class ChildEntry
    {
        public string Name;
        public bool IsContainer;
        public object Item;     // an S3ItemInfo
        public string Path;
    }

    /// <summary>
    /// Short-TTL listing cache, per drive, that collapses the repeated prefix probes the engine
    /// fires during one cd / tab-completion. One entry per prefix, tagged partial (presence only)
    /// vs complete (full child list, needed by Get-ChildItem); a full enumeration upgrades partial
    /// to complete. Drive-originated writes invalidate affected entries immediately (see InvalidateForKey).
    /// </summary>
    internal sealed class S3ListingCache
    {
        private sealed class Entry
        {
            public bool HasChildren;
            public List<ChildEntry> Items;   // non-null only when Complete
            public bool Complete;
            public DateTime FetchedUtc;
        }

        private readonly TimeSpan _ttl;
        private readonly ConcurrentDictionary<string, Entry> _entries =
            new ConcurrentDictionary<string, Entry>();

        // Per-child positive cache, populated as a listing streams (RecordChild), so the engine's
        // per-item decoration probes resolve with no network call - even mid-listing and for listings
        // too large to cache complete. Positive-only: a miss returns null, never asserts absence.
        // Flush-on-full keeps it O(1). (Distinct from the provider's like-sized ListingCacheMaxItems.)
        private const int ChildCacheCap = 10000;
        private readonly ConcurrentDictionary<string, CachedChild> _children =
            new ConcurrentDictionary<string, CachedChild>();

        private struct CachedChild { public bool IsContainer; public DateTime FetchedUtc; }

        // Existence-probe cache for an exact path (object HEAD or prefix probe), recording true and
        // false. Collapses the engine's repeated existence probes, including its deep-ancestor re-walks.
        // Two TTLs: a positive PREFIX result uses the longer _probeTtl (existence is stable, so it
        // survives a whole command); everything else uses the short _ttl so external changes aren't
        // hidden for long. Drive-originated writes call InvalidateForKey to drop entries at once.
        private readonly ConcurrentDictionary<string, (bool exists, DateTime at)> _existsProbes =
            new ConcurrentDictionary<string, (bool, DateTime)>();

        private readonly TimeSpan _probeTtl;

        internal S3ListingCache(TimeSpan ttl) : this(ttl, TimeSpan.FromSeconds(30)) { }

        // ttl: listings + negative probes. probeTtl: positive prefix probes (see _existsProbes).
        internal S3ListingCache(TimeSpan ttl, TimeSpan probeTtl) { _ttl = ttl; _probeTtl = probeTtl; }

        private static string Key(string bucket, string prefix) => bucket + "\0" + prefix;

        // Canonical key form: forward slashes, no surrounding slashes (so "a/b/" and "a/b" agree).
        private static string NormKey(string k) => (k ?? "").Replace('\\', '/').Trim('/');

        private bool Fresh(Entry e) => e != null && (DateTime.UtcNow - e.FetchedUtc) < _ttl;

        /// <summary>Cached "does this prefix have children?", or null if no fresh entry.</summary>
        internal bool? TryHasChildren(string bucket, string prefix)
        {
            if (_entries.TryGetValue(Key(bucket, prefix), out var e) && Fresh(e))
                return e.HasChildren;
            return null;
        }

        /// <summary>Cached COMPLETE child listing, or null if missing/partial/expired.</summary>
        internal List<ChildEntry> TryGetComplete(string bucket, string prefix)
        {
            if (_entries.TryGetValue(Key(bucket, prefix), out var e) && Fresh(e) && e.Complete)
                return e.Items;
            return null;
        }

        // Resolve childName under parentPrefix from the parent's complete cached listing, or null if
        // the parent isn't completely cached. Avoids a per-child probe during listing decoration.
        internal (bool exists, bool isContainer)? TryResolveChild(string bucket, string parentPrefix, string childName)
        {
            var items = TryGetComplete(bucket, parentPrefix);
            if (items == null) return null;
            foreach (var c in items)
                if (string.Equals(c.Name, childName, StringComparison.Ordinal))
                    return (true, c.IsContainer);
            return (false, false);   // complete listing + not present => definitively absent
        }

        /// <summary>Record a partial probe (presence only). Won't downgrade a fresh complete entry.</summary>
        internal void PutPartial(string bucket, string prefix, bool hasChildren)
        {
            var key = Key(bucket, prefix);
            if (_entries.TryGetValue(key, out var existing) && Fresh(existing) && existing.Complete)
                return; // keep the richer complete entry
            _entries[key] = new Entry { HasChildren = hasChildren, Complete = false, FetchedUtc = DateTime.UtcNow };
        }

        /// <summary>Record a full listing. Overlapping same-prefix listings are last-writer-wins
        /// (harmless: each is a consistent snapshot).</summary>
        internal void PutComplete(string bucket, string prefix, List<ChildEntry> items, bool prefixExists = false)
        {
            _entries[Key(bucket, prefix)] = new Entry
            {
                HasChildren = prefixExists || items.Count > 0,
                Items = items,
                Complete = true,
                FetchedUtc = DateTime.UtcNow
            };
        }

        // Record a child as a listing emits it, so the engine's per-item decoration resolves without a
        // network call. Flush-on-full keeps it O(1).
        internal void RecordChild(string bucket, string fullKey, bool isContainer)
        {
            if (_children.Count >= ChildCacheCap)
                _children.Clear();   // bounded: drop the lot; recently-emitted items get re-recorded
            _children[Key(bucket, NormKey(fullKey))] =
                new CachedChild { IsContainer = isContainer, FetchedUtc = DateTime.UtcNow };
        }

        // Positive-only lookup for a just-listed child, else null. A miss means "not recently listed",
        // not "absent".
        internal (bool exists, bool isContainer)? TryGetChild(string bucket, string key)
        {
            if (_children.TryGetValue(Key(bucket, NormKey(key)), out var c)
                && (DateTime.UtcNow - c.FetchedUtc) < _ttl)
                return (true, c.IsContainer);
            return null;
        }

        // Cached existence probe for an exact path, or null if none fresh. TTL per _existsProbes; the
        // object-vs-prefix kind is folded into the key so the two don't collide.
        internal bool? TryGetExistsProbe(string bucket, string key, bool asPrefix)
        {
            if (_existsProbes.TryGetValue(ProbeKey(bucket, key, asPrefix), out var p))
            {
                var age = DateTime.UtcNow - p.at;
                var ttl = p.exists && asPrefix ? _probeTtl : _ttl;
                if (age < ttl)
                    return p.exists;
            }
            return null;
        }

        /// <summary>Record the outcome of an existence probe (object HEAD or prefix probe).</summary>
        internal void PutExistsProbe(string bucket, string key, bool asPrefix, bool exists)
        {
            if (_existsProbes.Count >= ChildCacheCap)
                _existsProbes.Clear();   // bounded, same flush-on-full policy as the per-child cache
            _existsProbes[ProbeKey(bucket, key, asPrefix)] = (exists, DateTime.UtcNow);
        }

        // Distinct namespace per probe kind: "O\0" object HEAD, "P\0" prefix probe.
        private static string ProbeKey(string bucket, string key, bool asPrefix) =>
            (asPrefix ? "P\0" : "O\0") + Key(bucket, NormKey(key));

        internal void Clear() { _entries.Clear(); _children.Clear(); _existsProbes.Clear(); }

        /// <summary>
        /// Invalidate cache entries affected by a write/delete at bucket/key so the change shows
        /// immediately. Evicts the key's own listing and every ancestor prefix whose child set changed,
        /// plus the per-child records and existence probes for the key and everything beneath it (so a
        /// recursive delete leaves no descendant reading "exists"). Coarse but safe: over-eviction only
        /// costs a re-list.
        /// </summary>
        internal void InvalidateForKey(string bucket, string key)
        {
            var k = NormKey(key);

            // The key itself as a prefix (if it's a "folder"), plus every ancestor prefix.
            var prefixes = new List<string> { "" };           // bucket root listing
            var parts = k.Split('/');
            var acc = "";
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].Length == 0) continue;
                acc += parts[i] + "/";
                prefixes.Add(acc);                            // "a/", "a/b/", "a/b/c.txt/" ...
            }

            foreach (var p in prefixes)
            {
                _entries.TryRemove(Key(bucket, p), out _);
                // Drop each ancestor's prefix probe too: a write/delete can flip its "has children",
                // and a stale positive would otherwise linger for the long _probeTtl.
                _existsProbes.TryRemove(ProbeKey(bucket, p, asPrefix: true), out _);
                var childKey = NormKey(p);
                if (childKey.Length > 0)
                    _children.TryRemove(Key(bucket, childKey), out _);
            }

            // The exact key's per-child record and both existence-probe kinds.
            var normKey = NormKey(key);
            _children.TryRemove(Key(bucket, normKey), out _);
            _existsProbes.TryRemove(ProbeKey(bucket, normKey, asPrefix: false), out _);
            _existsProbes.TryRemove(ProbeKey(bucket, normKey, asPrefix: true), out _);

            // Everything beneath the key, for a recursive delete: scan "bucket\0normKey/". Bounded by
            // ChildCacheCap so it stays cheap. Skipped for the bucket root (nothing narrower to scan).
            if (normKey.Length > 0)
            {
                var descendantPrefix = Key(bucket, normKey) + "/";
                foreach (var childKey in _children.Keys)
                    if (childKey.StartsWith(descendantPrefix, StringComparison.Ordinal))
                        _children.TryRemove(childKey, out _);
                foreach (var entryKey in _entries.Keys)
                    if (entryKey.StartsWith(descendantPrefix, StringComparison.Ordinal))
                        _entries.TryRemove(entryKey, out _);
                // Probe keys carry an "O\0"/"P\0" prefix, so match on the bucket+key portion.
                foreach (var probeKey in _existsProbes.Keys)
                    if (probeKey.IndexOf(descendantPrefix, StringComparison.Ordinal) >= 0)
                        _existsProbes.TryRemove(probeKey, out _);
            }
        }
    }
}

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
    /// TTL-based listing cache, held per drive. Removes the within-operation redundancy where
    /// PowerShell probes the same prefix several times during one cd / tab-completion (each
    /// probe would otherwise be its own ListObjectsV2 round-trip).
    ///
    /// One entry per listed prefix, tagged partial vs complete:
    ///   * HasChildren is answerable from ANY entry (S3 returns >=1 result iff children exist,
    ///     so even a MaxKeys=1 probe is conclusive for presence).
    ///   * The full child list (Get-ChildItem) needs a COMPLETE entry; a partial one is a miss
    ///     and a full enumeration upgrades it to complete.
    ///
    /// TTL is short (1s) - sized for the burst, minimal staleness. Drive-originated writes
    /// (Set-Content/Copy-Item/Remove-Item) invalidate affected entries immediately so the
    /// change shows on the next ls without waiting for the TTL.
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

        // Per-child POSITIVE cache: "this exact key was just emitted by a listing - it exists
        // and here's whether it's a container." Populated INCREMENTALLY as items stream (see
        // RecordChild), so the per-item decoration probe PowerShell fires DURING a listing
        // (ItemExists/IsItemContainer on each emitted child) resolves with NO network call -
        // even before the listing finishes, and even for listings too large to cache as a
        // COMPLETE entry. Positive-only: a miss returns null and the caller falls back; it never
        // asserts absence. Bounded by flush-on-full so a huge listing stays O(1) memory (the
        // recently-emitted items being decorated survive, since decoration tracks emission).
        // Note: this bounds the per-child positive cache (a count of individual recorded children).
        // The provider has a separate, coincidentally-equal cap on per-listing accumulation
        // (ListingCacheMaxItems); they bound different structures and may diverge independently.
        private const int ChildCacheCap = 10000;
        private readonly ConcurrentDictionary<string, CachedChild> _children =
            new ConcurrentDictionary<string, CachedChild>();

        private struct CachedChild { public bool IsContainer; public DateTime FetchedUtc; }

        // Existence-probe cache: the result of a direct existence check on an EXACT path - either an
        // object HEAD (GetObjectMetadata) or a prefix probe (ListObjectsV2 MaxKeys=1). Records both
        // true AND false. This collapses the storm of redundant existence probes the engine fires for
        // ONE command: the engine spins up a FRESH provider instance every ~2 calls and re-resolves
        // ItemExists/IsItemContainer dozens of times, and for a DEEP path it re-walks the entire
        // ancestor chain (`.../L14/`, `.../L13/`, ... ) on each pass. Those probes are the dominant
        // per-command latency (a 15-level Get-Content made 254 S3 calls / ~20s).
        //
        // TWO TTLs, because prefix existence is far more STABLE than a directory listing:
        //   * a POSITIVE PREFIX result (it exists) is cached for the LONGER _probeTtl - long enough
        //     to survive a whole command, which is what breaks the deep-walk feedback loop (a single
        //     ancestor walk of 15 misses x ~78ms ALREADY exceeds a 1s TTL, so a short TTL expires
        //     before the next pass reuses it -> pure thrash). Positive OBJECT probes use the short
        //     _ttl so external object deletes are not hidden for 30s.
        //   * a NEGATIVE result (absent) is cached only for the SHORT _ttl, so "create it externally,
        //     then Test-Path" stays responsive (a just-created object isn't wrongly reported absent
        //     for long). Drive-originated writes/deletes call InvalidateForKey, which drops the entry
        //     immediately regardless of TTL, so the common create-through-the-drive path is instant.
        // Bounded by ChildCacheCap with the same flush-on-full policy as the per-child cache.
        private readonly ConcurrentDictionary<string, (bool exists, DateTime at)> _existsProbes =
            new ConcurrentDictionary<string, (bool, DateTime)>();

        private readonly TimeSpan _probeTtl;

        internal S3ListingCache(TimeSpan ttl) : this(ttl, TimeSpan.FromSeconds(30)) { }

        // ttl: short TTL for listings + negative probes (staleness-sensitive). probeTtl: longer TTL
        // for POSITIVE existence probes (existence is stable; this is what de-thrashes deep walks).
        internal S3ListingCache(TimeSpan ttl, TimeSpan probeTtl) { _ttl = ttl; _probeTtl = probeTtl; }

        private static string Key(string bucket, string prefix) => bucket + "\0" + prefix;

        // Canonical key form matching what ParsePath produces on the lookup side: forward
        // slashes, no surrounding slashes (so a folder "a/b/" and a probe for "a/b" agree).
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

        /// <summary>
        /// Answer "does childName exist under parentPrefix, and is it a container?" from the
        /// parent's COMPLETE cached listing - WITHOUT a network call. Returns null if the
        /// parent isn't completely cached (caller must fall back to S3). This is what avoids
        /// a per-child ListObjectsV2 probe when PowerShell decorates each listed item during
        /// completion/Get-ChildItem.
        /// </summary>
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

        /// <summary>Record a full listing (answers both presence and full enumeration). Two
        /// overlapping same-prefix listings are last-writer-wins, which is harmless: each is an
        /// internally consistent complete snapshot, bounded by the short TTL.</summary>
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

        /// <summary>
        /// Record a child the instant a listing emits it, so the engine's per-item decoration
        /// probe (ItemExists/IsItemContainer) resolves without a network call - the fix for the
        /// per-item probe storm on large listings. Flush-on-full keeps it O(1) for huge listings.
        /// </summary>
        internal void RecordChild(string bucket, string fullKey, bool isContainer)
        {
            if (_children.Count >= ChildCacheCap)
                _children.Clear();   // bounded: drop the lot; recently-emitted items get re-recorded
            _children[Key(bucket, NormKey(fullKey))] =
                new CachedChild { IsContainer = isContainer, FetchedUtc = DateTime.UtcNow };
        }

        /// <summary>
        /// Positive-only lookup for a just-listed child: (exists:true, isContainer) if a fresh
        /// record is present, else null (caller falls back to a network check). Never returns
        /// "absent" - absence of a record just means "not recently listed", not "doesn't exist".
        /// </summary>
        internal (bool exists, bool isContainer)? TryGetChild(string bucket, string key)
        {
            if (_children.TryGetValue(Key(bucket, NormKey(key)), out var c)
                && (DateTime.UtcNow - c.FetchedUtc) < _ttl)
                return (true, c.IsContainer);
            return null;
        }

        /// <summary>Cached result of a direct existence probe (object HEAD or prefix probe) on an
        /// exact path, or null if no fresh probe. Positive results live for the longer _probeTtl;
        /// negative results only for the short _ttl (see the _existsProbes comment). The 'kind'
        /// (object vs prefix) is folded into the key so an object probe and a prefix probe for the
        /// same name don't collide.</summary>
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
        /// Invalidate cache entries affected by a write/delete at bucket/key, so the change
        /// shows immediately (no waiting for TTL). We evict every cached prefix that is an
        /// ancestor of the key - the key's own listing AND each parent whose child set just
        /// changed. Cheap and correct: a write under "a/b/c.txt" touches the listings of
        /// "", "a/", and "a/b/"; clearing ancestors covers all of them. (Coarse but safe -
        /// over-eviction only costs a re-list, never staleness.)
        ///
        /// Also drops the per-child positive records for the exact key AND everything beneath it,
        /// so that after a recursive prefix delete no descendant is still reported "exists" from a
        /// stale record within the TTL window.
        /// </summary>
        internal void InvalidateForKey(string bucket, string key)
        {
            // Normalize the same way as every other cache key (forward slashes, no surrounding
            // slashes). The ancestor loop below splits on '/' and skips empty segments, so trimming
            // a trailing slash here is harmless and keeps normalization consistent with NormKey.
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
                // Also drop the PREFIX existence-probe for each ancestor: a write/delete can flip
                // whether an ancestor "has children" (e.g. deleting the last object under "a/b/"),
                // and - because positive prefix probes live for the LONG _probeTtl - a stale
                // positive would otherwise linger. Cheap: one dictionary remove per ancestor level.
                _existsProbes.TryRemove(ProbeKey(bucket, p, asPrefix: true), out _);
                var childKey = NormKey(p);
                if (childKey.Length > 0)
                    _children.TryRemove(Key(bucket, childKey), out _);
            }

            // Drop the per-child positive record for this exact key, so a deleted/overwritten
            // object isn't reported "exists" from a stale record within the TTL window.
            var normKey = NormKey(key);
            _children.TryRemove(Key(bucket, normKey), out _);

            // Same for BOTH existence-probe kinds at this exact key (object HEAD and prefix): a
            // write/delete makes any recorded outcome stale, so a deleted object must not read back
            // "exists", nor a freshly-written one read back "absent", within the (long) probe TTL.
            _existsProbes.TryRemove(ProbeKey(bucket, normKey, asPrefix: false), out _);
            _existsProbes.TryRemove(ProbeKey(bucket, normKey, asPrefix: true), out _);

            // Drop descendant per-child records AND descendant existence-probes too (a recursive
            // delete removes everything under the prefix). Scan for keys under "bucket\0normKey/".
            // Bounded by ChildCacheCap (10k), so this stays cheap. Skipped when normKey is empty
            // (bucket root) - nothing more specific to scan than the whole map, and a root-level
            // write only affects the exact key already removed above.
            if (normKey.Length > 0)
            {
                var descendantPrefix = Key(bucket, normKey) + "/";
                foreach (var childKey in _children.Keys)
                    if (childKey.StartsWith(descendantPrefix, StringComparison.Ordinal))
                        _children.TryRemove(childKey, out _);
                // Descendant LISTING entries too: a recursive delete of "a/b" empties "a/b/c/" etc.,
                // whose cached listings would otherwise report stale children. (The ancestor loop
                // above only covers ancestors + the key itself; descendants need this scan. This also
                // fixes a pre-existing gap where an intermediate descendant prefix read stale after a
                // recursive delete.) _entries keys are "bucket\0prefix" (no kind tag) => StartsWith.
                foreach (var entryKey in _entries.Keys)
                    if (entryKey.StartsWith(descendantPrefix, StringComparison.Ordinal))
                        _entries.TryRemove(entryKey, out _);
                // Existence-probe keys carry a "O\0"/"P\0" prefix, so match the descendant on the
                // bucket+key portion regardless of kind.
                foreach (var probeKey in _existsProbes.Keys)
                    if (probeKey.IndexOf(descendantPrefix, StringComparison.Ordinal) >= 0)
                        _existsProbes.TryRemove(probeKey, out _);
            }
        }
    }
}

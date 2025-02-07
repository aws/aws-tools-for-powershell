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
using System.Linq;
using System.Text;

namespace Amazon.PowerShell.Utils
{
    public class Lazy2<T>
    {
        private bool isThreadSafe = false;
        private bool isValueCreated = false;
        private T value;
        private Func<T> generator;

        public Lazy2(T value)
            : this(() => value) { }
        public Lazy2(Func<T> generator)
            : this(generator, false) { }
        private Lazy2(Func<T> generator, bool isThreadSafe)
        {
            this.generator = generator;
            this.isThreadSafe = isThreadSafe;
        }

        public bool IsValueCreated { get { return isValueCreated; } }
        public T Value
        {
            get
            {
                if (!isValueCreated)
                {
                    value = generator();
                    isValueCreated = true;
                }
                return value;
            }
        }
        public void Reset()
        {
            isValueCreated = false;
        }
    }

    public static class Lazy2Extensions
    {
        public static void SafeReset<T>(this Lazy2<T> self)
        {
            if (self != null)
                self.Reset();
        }
    }
}

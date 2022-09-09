/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License").
 *  You may not use this file except in compliance with the License.
 *  A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file. This file is distributed 
 *  on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either 
 *  express or implied. See the License for the specific language governing 
 *  permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using Amazon.PowerShell.Cmdlets.S3;
using Amazon.PowerShell.Common;
using System;
using System.Management.Automation;

namespace Amazon.PowerShell.Tests
{
    [Cmdlet("Test", "S3ClientConfig")]
    public partial class TestS3ClientConfigCmdLet : AmazonS3ClientCmdlet, IExecutor
    {
        protected override void ProcessRecord()
        {
            WriteObject(Execute(null));
        }

        public object Execute(ExecutorContext context)
        {
            base.ProcessRecord(); // ProcessRecord resolves region and sets up the Client property.
            return Client;
        }

        public ExecutorContext CreateContext()
        {
            throw new NotImplementedException();
        }
    }
}

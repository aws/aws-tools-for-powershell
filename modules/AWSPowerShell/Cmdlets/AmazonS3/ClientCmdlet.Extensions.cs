/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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

using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.S3;

namespace Amazon.PowerShell.Cmdlets.S3
{
    public abstract partial class AmazonS3ClientCmdlet
    {        
        protected override void CustomizeClientConfig(ClientConfig config)
        {
            base.CustomizeClientConfig(config);

            var s3Config = (AmazonS3Config)config;
            var useAccelerateEndpoint = ParameterWasBound("UseAccelerateEndpoint");
            var useDualstackEndpoint = ParameterWasBound("UseDualstackEndpoint");
            s3Config.ResignRetries = true;

            // let the underlying sdk determine if using these together is allowed
            if (useAccelerateEndpoint)
                s3Config.UseAccelerateEndpoint = true;

            if (useDualstackEndpoint)
                s3Config.UseDualstackEndpoint = true;

            // github issue #670 request - like the aws cli, if a specific endpoint is
            // given then switch to path style addressing
            if (ParameterWasBound("EndpointUrl"))
                s3Config.ForcePathStyle = true;
        }
    }
}

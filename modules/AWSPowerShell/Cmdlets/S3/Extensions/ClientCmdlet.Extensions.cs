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

using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.S3;

namespace Amazon.PowerShell.Cmdlets.S3
{
    public abstract partial class AmazonS3ClientCmdlet
    {
        #region Parameter UseAccelerateEndpoint
        /// <summary>
        /// Enables S3 accelerate by sending requests to the accelerate endpoint instead of the regular region endpoint.
        /// To use this feature, the bucket name must be DNS compliant and must not contain periods (.). 
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter UseAccelerateEndpoint { get; set; }
        
        #endregion
        
        #region Parameter UseDualstackEndpoint
        /// <summary>
        /// Configures the request to Amazon S3 to use the dualstack endpoint for a region.
        /// S3 supports dualstack endpoints which return both IPv6 and IPv4 values.
        /// The dualstack mode of Amazon S3 cannot be used with accelerate mode.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter UseDualstackEndpoint { get; set; }

        #endregion

        #region Parameter ForcePathStyleAddressing
        /// <summary>
        /// S3 requests can be performed using one of two URI styles: Virtual or Path.
        /// When using Virtual style, the bucket is included as part of the hostname. 
        /// When using Path style the bucket is included as part of the URI path.
        /// The default value is $true when the EndpointUrl parameter is specified, $false otherwise.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public bool? ForcePathStyleAddressing { get; set; }

        #endregion

        protected override void CustomizeClientConfig(ClientConfig config)
        {
            base.CustomizeClientConfig(config);

            var s3Config = (AmazonS3Config)config;
            var useAccelerateEndpoint = ParameterWasBound(nameof(UseAccelerateEndpoint));
            var useDualstackEndpoint = ParameterWasBound(nameof(UseDualstackEndpoint));
            s3Config.ResignRetries = true;

            // let the underlying sdk determine if using these together is allowed
            if (useAccelerateEndpoint)
                s3Config.UseAccelerateEndpoint = true;

            if (useDualstackEndpoint)
                s3Config.UseDualstackEndpoint = true;

            // github issue #670 request - like the aws cli, if a specific endpoint is
            // given then switch to path style addressing. If ForcePathStyle is explicitly set in ClientConfig, then use it.
            s3Config.ForcePathStyle = ForcePathStyleAddressing ?? (s3Config.ForcePathStyle || ParameterWasBound(nameof(EndpointUrl)));
        }
    }
}

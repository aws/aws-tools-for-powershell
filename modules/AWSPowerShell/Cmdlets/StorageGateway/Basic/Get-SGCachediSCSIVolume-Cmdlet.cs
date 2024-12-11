/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Returns a description of the gateway volumes specified in the request. This operation
    /// is only supported in the cached volume gateway types.
    /// 
    ///  
    /// <para>
    /// The list of gateway volumes in the request must be from one gateway. In the response,
    /// Storage Gateway returns volume information sorted by volume Amazon Resource Name (ARN).
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SGCachediSCSIVolume")]
    [OutputType("Amazon.StorageGateway.Model.CachediSCSIVolume")]
    [AWSCmdlet("Calls the AWS Storage Gateway DescribeCachediSCSIVolumes API operation.", Operation = new[] {"DescribeCachediSCSIVolumes"}, SelectReturnType = typeof(Amazon.StorageGateway.Model.DescribeCachediSCSIVolumesResponse))]
    [AWSCmdletOutput("Amazon.StorageGateway.Model.CachediSCSIVolume or Amazon.StorageGateway.Model.DescribeCachediSCSIVolumesResponse",
        "This cmdlet returns a collection of Amazon.StorageGateway.Model.CachediSCSIVolume objects.",
        "The service call response (type Amazon.StorageGateway.Model.DescribeCachediSCSIVolumesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSGCachediSCSIVolumeCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter VolumeARNs
        /// <summary>
        /// <para>
        /// <para>An array of strings where each string represents the Amazon Resource Name (ARN) of
        /// a cached volume. All of the specified cached volumes must be from the same gateway.
        /// Use <a>ListVolumes</a> to get volume ARNs for a gateway.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String[] VolumeARNs { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CachediSCSIVolumes'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StorageGateway.Model.DescribeCachediSCSIVolumesResponse).
        /// Specifying the name of a property of type Amazon.StorageGateway.Model.DescribeCachediSCSIVolumesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CachediSCSIVolumes";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StorageGateway.Model.DescribeCachediSCSIVolumesResponse, GetSGCachediSCSIVolumeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.VolumeARNs != null)
            {
                context.VolumeARNs = new List<System.String>(this.VolumeARNs);
            }
            #if MODULAR
            if (this.VolumeARNs == null && ParameterWasBound(nameof(this.VolumeARNs)))
            {
                WriteWarning("You are passing $null as a value for parameter VolumeARNs which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.StorageGateway.Model.DescribeCachediSCSIVolumesRequest();
            
            if (cmdletContext.VolumeARNs != null)
            {
                request.VolumeARNs = cmdletContext.VolumeARNs;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.StorageGateway.Model.DescribeCachediSCSIVolumesResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.DescribeCachediSCSIVolumesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "DescribeCachediSCSIVolumes");
            try
            {
                #if DESKTOP
                return client.DescribeCachediSCSIVolumes(request);
                #elif CORECLR
                return client.DescribeCachediSCSIVolumesAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public List<System.String> VolumeARNs { get; set; }
            public System.Func<Amazon.StorageGateway.Model.DescribeCachediSCSIVolumesResponse, GetSGCachediSCSIVolumeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CachediSCSIVolumes;
        }
        
    }
}

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
    /// Returns the description of the gateway volumes specified in the request. The list
    /// of gateway volumes in the request must be from one gateway. In the response, Storage
    /// Gateway returns volume information sorted by volume ARNs. This operation is only supported
    /// in stored volume gateway type.
    /// </summary>
    [Cmdlet("Get", "SGStorediSCSIVolume")]
    [OutputType("Amazon.StorageGateway.Model.StorediSCSIVolume")]
    [AWSCmdlet("Calls the AWS Storage Gateway DescribeStorediSCSIVolumes API operation.", Operation = new[] {"DescribeStorediSCSIVolumes"}, SelectReturnType = typeof(Amazon.StorageGateway.Model.DescribeStorediSCSIVolumesResponse))]
    [AWSCmdletOutput("Amazon.StorageGateway.Model.StorediSCSIVolume or Amazon.StorageGateway.Model.DescribeStorediSCSIVolumesResponse",
        "This cmdlet returns a collection of Amazon.StorageGateway.Model.StorediSCSIVolume objects.",
        "The service call response (type Amazon.StorageGateway.Model.DescribeStorediSCSIVolumesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSGStorediSCSIVolumeCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter VolumeARNs
        /// <summary>
        /// <para>
        /// <para>An array of strings where each string represents the Amazon Resource Name (ARN) of
        /// a stored volume. All of the specified stored volumes must be from the same gateway.
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StorediSCSIVolumes'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StorageGateway.Model.DescribeStorediSCSIVolumesResponse).
        /// Specifying the name of a property of type Amazon.StorageGateway.Model.DescribeStorediSCSIVolumesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StorediSCSIVolumes";
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
                context.Select = CreateSelectDelegate<Amazon.StorageGateway.Model.DescribeStorediSCSIVolumesResponse, GetSGStorediSCSIVolumeCmdlet>(Select) ??
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
            var request = new Amazon.StorageGateway.Model.DescribeStorediSCSIVolumesRequest();
            
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
        
        private Amazon.StorageGateway.Model.DescribeStorediSCSIVolumesResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.DescribeStorediSCSIVolumesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "DescribeStorediSCSIVolumes");
            try
            {
                #if DESKTOP
                return client.DescribeStorediSCSIVolumes(request);
                #elif CORECLR
                return client.DescribeStorediSCSIVolumesAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.StorageGateway.Model.DescribeStorediSCSIVolumesResponse, GetSGStorediSCSIVolumeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StorediSCSIVolumes;
        }
        
    }
}

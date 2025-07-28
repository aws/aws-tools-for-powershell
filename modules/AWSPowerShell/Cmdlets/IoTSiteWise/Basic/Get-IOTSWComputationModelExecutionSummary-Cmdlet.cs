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
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.IoTSiteWise;
using Amazon.IoTSiteWise.Model;

namespace Amazon.PowerShell.Cmdlets.IOTSW
{
    /// <summary>
    /// Retrieves information about the execution summary of a computation model.
    /// </summary>
    [Cmdlet("Get", "IOTSWComputationModelExecutionSummary")]
    [OutputType("Amazon.IoTSiteWise.Model.DescribeComputationModelExecutionSummaryResponse")]
    [AWSCmdlet("Calls the AWS IoT SiteWise DescribeComputationModelExecutionSummary API operation.", Operation = new[] {"DescribeComputationModelExecutionSummary"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.DescribeComputationModelExecutionSummaryResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.DescribeComputationModelExecutionSummaryResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.DescribeComputationModelExecutionSummaryResponse object containing multiple properties."
    )]
    public partial class GetIOTSWComputationModelExecutionSummaryCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ComputationModelId
        /// <summary>
        /// <para>
        /// <para>The ID of the computation model.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ComputationModelId { get; set; }
        #endregion
        
        #region Parameter ResolveToResourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the resolved resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResolveToResourceId { get; set; }
        #endregion
        
        #region Parameter ResolveToResourceType
        /// <summary>
        /// <para>
        /// <para>The type of the resolved resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTSiteWise.ResolveToResourceType")]
        public Amazon.IoTSiteWise.ResolveToResourceType ResolveToResourceType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.DescribeComputationModelExecutionSummaryResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.DescribeComputationModelExecutionSummaryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ComputationModelId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ComputationModelId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ComputationModelId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.DescribeComputationModelExecutionSummaryResponse, GetIOTSWComputationModelExecutionSummaryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ComputationModelId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ComputationModelId = this.ComputationModelId;
            #if MODULAR
            if (this.ComputationModelId == null && ParameterWasBound(nameof(this.ComputationModelId)))
            {
                WriteWarning("You are passing $null as a value for parameter ComputationModelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResolveToResourceId = this.ResolveToResourceId;
            context.ResolveToResourceType = this.ResolveToResourceType;
            
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
            var request = new Amazon.IoTSiteWise.Model.DescribeComputationModelExecutionSummaryRequest();
            
            if (cmdletContext.ComputationModelId != null)
            {
                request.ComputationModelId = cmdletContext.ComputationModelId;
            }
            if (cmdletContext.ResolveToResourceId != null)
            {
                request.ResolveToResourceId = cmdletContext.ResolveToResourceId;
            }
            if (cmdletContext.ResolveToResourceType != null)
            {
                request.ResolveToResourceType = cmdletContext.ResolveToResourceType;
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
        
        private Amazon.IoTSiteWise.Model.DescribeComputationModelExecutionSummaryResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.DescribeComputationModelExecutionSummaryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "DescribeComputationModelExecutionSummary");
            try
            {
                #if DESKTOP
                return client.DescribeComputationModelExecutionSummary(request);
                #elif CORECLR
                return client.DescribeComputationModelExecutionSummaryAsync(request).GetAwaiter().GetResult();
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
            public System.String ComputationModelId { get; set; }
            public System.String ResolveToResourceId { get; set; }
            public Amazon.IoTSiteWise.ResolveToResourceType ResolveToResourceType { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.DescribeComputationModelExecutionSummaryResponse, GetIOTSWComputationModelExecutionSummaryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

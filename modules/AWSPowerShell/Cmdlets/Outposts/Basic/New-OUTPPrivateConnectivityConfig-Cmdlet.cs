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
using System.Threading;
using Amazon.Outposts;
using Amazon.Outposts.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.OUTP
{
    /// <summary>
    /// Creates the private connectivity configuration for the specified Outpost. Private
    /// connectivity establishes a service link VPN connection between the Outpost and its
    /// home Amazon Web Services Region using a VPC and subnet that you specify, which allows
    /// the service link traffic to flow through your VPC and minimizes public internet exposure.
    /// </summary>
    [Cmdlet("New", "OUTPPrivateConnectivityConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Outposts.Model.CreatePrivateConnectivityConfigResponse")]
    [AWSCmdlet("Calls the AWS Outposts CreatePrivateConnectivityConfig API operation.", Operation = new[] {"CreatePrivateConnectivityConfig"}, SelectReturnType = typeof(Amazon.Outposts.Model.CreatePrivateConnectivityConfigResponse))]
    [AWSCmdletOutput("Amazon.Outposts.Model.CreatePrivateConnectivityConfigResponse",
        "This cmdlet returns an Amazon.Outposts.Model.CreatePrivateConnectivityConfigResponse object containing multiple properties."
    )]
    public partial class NewOUTPPrivateConnectivityConfigCmdlet : AmazonOutpostsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter OutpostId
        /// <summary>
        /// <para>
        /// <para>The ID or ARN of the Outpost.</para>
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
        public System.String OutpostId { get; set; }
        #endregion
        
        #region Parameter VpcInformationList
        /// <summary>
        /// <para>
        /// <para>Information about the VPC used for private connectivity, including the VPC, its subnets,
        /// and an associated VPC endpoint. You can specify at most one entry.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.Outposts.Model.VpcInformation[] VpcInformationList { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Outposts.Model.CreatePrivateConnectivityConfigResponse).
        /// Specifying the name of a property of type Amazon.Outposts.Model.CreatePrivateConnectivityConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OutpostId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OUTPPrivateConnectivityConfig (CreatePrivateConnectivityConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Outposts.Model.CreatePrivateConnectivityConfigResponse, NewOUTPPrivateConnectivityConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.OutpostId = this.OutpostId;
            #if MODULAR
            if (this.OutpostId == null && ParameterWasBound(nameof(this.OutpostId)))
            {
                WriteWarning("You are passing $null as a value for parameter OutpostId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.VpcInformationList != null)
            {
                context.VpcInformationList = new List<Amazon.Outposts.Model.VpcInformation>(this.VpcInformationList);
            }
            #if MODULAR
            if (this.VpcInformationList == null && ParameterWasBound(nameof(this.VpcInformationList)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcInformationList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Outposts.Model.CreatePrivateConnectivityConfigRequest();
            
            if (cmdletContext.OutpostId != null)
            {
                request.OutpostId = cmdletContext.OutpostId;
            }
            if (cmdletContext.VpcInformationList != null)
            {
                request.VpcInformationList = cmdletContext.VpcInformationList;
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
        
        private Amazon.Outposts.Model.CreatePrivateConnectivityConfigResponse CallAWSServiceOperation(IAmazonOutposts client, Amazon.Outposts.Model.CreatePrivateConnectivityConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Outposts", "CreatePrivateConnectivityConfig");
            try
            {
                return client.CreatePrivateConnectivityConfigAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String OutpostId { get; set; }
            public List<Amazon.Outposts.Model.VpcInformation> VpcInformationList { get; set; }
            public System.Func<Amazon.Outposts.Model.CreatePrivateConnectivityConfigResponse, NewOUTPPrivateConnectivityConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

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
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DC
{
    /// <summary>
    /// Creates a resiliency group. A resiliency group lets you group Direct Connect connections
    /// together and manage them as a single unit to meet a target resiliency model.
    /// </summary>
    [Cmdlet("New", "DCResiliencyGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.ResiliencyGroup")]
    [AWSCmdlet("Calls the AWS Direct Connect CreateResiliencyGroup API operation.", Operation = new[] {"CreateResiliencyGroup"}, SelectReturnType = typeof(Amazon.DirectConnect.Model.CreateResiliencyGroupResponse))]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.ResiliencyGroup or Amazon.DirectConnect.Model.CreateResiliencyGroupResponse",
        "This cmdlet returns an Amazon.DirectConnect.Model.ResiliencyGroup object.",
        "The service call response (type Amazon.DirectConnect.Model.CreateResiliencyGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewDCResiliencyGroupCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IntendedResiliencyModel
        /// <summary>
        /// <para>
        /// <para>The resiliency model that the resiliency group is intended to meet. The valid values
        /// are <c>maximum-resiliency</c>, <c>high-resiliency</c>, and <c>basic-resiliency</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DirectConnect.ResiliencyModel")]
        public Amazon.DirectConnect.ResiliencyModel IntendedResiliencyModel { get; set; }
        #endregion
        
        #region Parameter ResiliencyGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the resiliency group.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ResiliencyGroupName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to associate with the resiliency group.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DirectConnect.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResiliencyGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectConnect.Model.CreateResiliencyGroupResponse).
        /// Specifying the name of a property of type Amazon.DirectConnect.Model.CreateResiliencyGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResiliencyGroup";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResiliencyGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DCResiliencyGroup (CreateResiliencyGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectConnect.Model.CreateResiliencyGroupResponse, NewDCResiliencyGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.IntendedResiliencyModel = this.IntendedResiliencyModel;
            #if MODULAR
            if (this.IntendedResiliencyModel == null && ParameterWasBound(nameof(this.IntendedResiliencyModel)))
            {
                WriteWarning("You are passing $null as a value for parameter IntendedResiliencyModel which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResiliencyGroupName = this.ResiliencyGroupName;
            #if MODULAR
            if (this.ResiliencyGroupName == null && ParameterWasBound(nameof(this.ResiliencyGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter ResiliencyGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.DirectConnect.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.DirectConnect.Model.CreateResiliencyGroupRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.IntendedResiliencyModel != null)
            {
                request.IntendedResiliencyModel = cmdletContext.IntendedResiliencyModel;
            }
            if (cmdletContext.ResiliencyGroupName != null)
            {
                request.ResiliencyGroupName = cmdletContext.ResiliencyGroupName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.DirectConnect.Model.CreateResiliencyGroupResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.CreateResiliencyGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "CreateResiliencyGroup");
            try
            {
                return client.CreateResiliencyGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public Amazon.DirectConnect.ResiliencyModel IntendedResiliencyModel { get; set; }
            public System.String ResiliencyGroupName { get; set; }
            public List<Amazon.DirectConnect.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.DirectConnect.Model.CreateResiliencyGroupResponse, NewDCResiliencyGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResiliencyGroup;
        }
        
    }
}

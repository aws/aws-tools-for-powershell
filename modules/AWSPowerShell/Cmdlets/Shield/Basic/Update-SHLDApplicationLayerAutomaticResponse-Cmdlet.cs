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
using Amazon.Shield;
using Amazon.Shield.Model;

namespace Amazon.PowerShell.Cmdlets.SHLD
{
    /// <summary>
    /// Updates an existing Shield Advanced automatic application layer DDoS mitigation configuration
    /// for the specified resource.
    /// </summary>
    [Cmdlet("Update", "SHLDApplicationLayerAutomaticResponse", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Shield UpdateApplicationLayerAutomaticResponse API operation.", Operation = new[] {"UpdateApplicationLayerAutomaticResponse"}, SelectReturnType = typeof(Amazon.Shield.Model.UpdateApplicationLayerAutomaticResponseResponse))]
    [AWSCmdletOutput("None or Amazon.Shield.Model.UpdateApplicationLayerAutomaticResponseResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Shield.Model.UpdateApplicationLayerAutomaticResponseResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSHLDApplicationLayerAutomaticResponseCmdlet : AmazonShieldClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Action_Block
        /// <summary>
        /// <para>
        /// <para>Specifies that Shield Advanced should configure its WAF rules with the WAF <c>Block</c>
        /// action. </para><para>You must specify exactly one action, either <c>Block</c> or <c>Count</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Shield.Model.BlockAction Action_Block { get; set; }
        #endregion
        
        #region Parameter Action_Count
        /// <summary>
        /// <para>
        /// <para>Specifies that Shield Advanced should configure its WAF rules with the WAF <c>Count</c>
        /// action. </para><para>You must specify exactly one action, either <c>Block</c> or <c>Count</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Shield.Model.CountAction Action_Count { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The ARN (Amazon Resource Name) of the resource.</para>
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
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Shield.Model.UpdateApplicationLayerAutomaticResponseResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SHLDApplicationLayerAutomaticResponse (UpdateApplicationLayerAutomaticResponse)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Shield.Model.UpdateApplicationLayerAutomaticResponseResponse, UpdateSHLDApplicationLayerAutomaticResponseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Action_Block = this.Action_Block;
            context.Action_Count = this.Action_Count;
            context.ResourceArn = this.ResourceArn;
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Shield.Model.UpdateApplicationLayerAutomaticResponseRequest();
            
            
             // populate Action
            var requestActionIsNull = true;
            request.Action = new Amazon.Shield.Model.ResponseAction();
            Amazon.Shield.Model.BlockAction requestAction_action_Block = null;
            if (cmdletContext.Action_Block != null)
            {
                requestAction_action_Block = cmdletContext.Action_Block;
            }
            if (requestAction_action_Block != null)
            {
                request.Action.Block = requestAction_action_Block;
                requestActionIsNull = false;
            }
            Amazon.Shield.Model.CountAction requestAction_action_Count = null;
            if (cmdletContext.Action_Count != null)
            {
                requestAction_action_Count = cmdletContext.Action_Count;
            }
            if (requestAction_action_Count != null)
            {
                request.Action.Count = requestAction_action_Count;
                requestActionIsNull = false;
            }
             // determine if request.Action should be set to null
            if (requestActionIsNull)
            {
                request.Action = null;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
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
        
        private Amazon.Shield.Model.UpdateApplicationLayerAutomaticResponseResponse CallAWSServiceOperation(IAmazonShield client, Amazon.Shield.Model.UpdateApplicationLayerAutomaticResponseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Shield", "UpdateApplicationLayerAutomaticResponse");
            try
            {
                #if DESKTOP
                return client.UpdateApplicationLayerAutomaticResponse(request);
                #elif CORECLR
                return client.UpdateApplicationLayerAutomaticResponseAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Shield.Model.BlockAction Action_Block { get; set; }
            public Amazon.Shield.Model.CountAction Action_Count { get; set; }
            public System.String ResourceArn { get; set; }
            public System.Func<Amazon.Shield.Model.UpdateApplicationLayerAutomaticResponseResponse, UpdateSHLDApplicationLayerAutomaticResponseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

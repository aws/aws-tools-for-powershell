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
using Amazon.Shield;
using Amazon.Shield.Model;

namespace Amazon.PowerShell.Cmdlets.SHLD
{
    /// <summary>
    /// Enable the Shield Advanced automatic application layer DDoS mitigation for the protected
    /// resource. 
    /// 
    ///  <note><para>
    /// This feature is available for Amazon CloudFront distributions and Application Load
    /// Balancers only.
    /// </para></note><para>
    /// This causes Shield Advanced to create, verify, and apply WAF rules for DDoS attacks
    /// that it detects for the resource. Shield Advanced applies the rules in a Shield rule
    /// group inside the web ACL that you've associated with the resource. For information
    /// about how automatic mitigation works and the requirements for using it, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/ddos-advanced-automatic-app-layer-response.html">Shield
    /// Advanced automatic application layer DDoS mitigation</a>.
    /// </para><note><para>
    /// Don't use this action to make changes to automatic mitigation settings when it's already
    /// enabled for a resource. Instead, use <a>UpdateApplicationLayerAutomaticResponse</a>.
    /// </para></note><para>
    /// To use this feature, you must associate a web ACL with the protected resource. The
    /// web ACL must be created using the latest version of WAF (v2). You can associate the
    /// web ACL through the Shield Advanced console at <a href="https://console.aws.amazon.com/wafv2/shieldv2#/">https://console.aws.amazon.com/wafv2/shieldv2#/</a>.
    /// For more information, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/getting-started-ddos.html">Getting
    /// Started with Shield Advanced</a>. You can also associate the web ACL to the resource
    /// through the WAF console or the WAF API, but you must manage Shield Advanced automatic
    /// mitigation through Shield Advanced. For information about WAF, see <a href="https://docs.aws.amazon.com/waf/latest/developerguide/">WAF
    /// Developer Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Enable", "SHLDApplicationLayerAutomaticResponse", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Shield EnableApplicationLayerAutomaticResponse API operation.", Operation = new[] {"EnableApplicationLayerAutomaticResponse"}, SelectReturnType = typeof(Amazon.Shield.Model.EnableApplicationLayerAutomaticResponseResponse))]
    [AWSCmdletOutput("None or Amazon.Shield.Model.EnableApplicationLayerAutomaticResponseResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Shield.Model.EnableApplicationLayerAutomaticResponseResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EnableSHLDApplicationLayerAutomaticResponseCmdlet : AmazonShieldClientCmdlet, IExecutor
    {
        
        #region Parameter Action_Block
        /// <summary>
        /// <para>
        /// <para>Specifies that Shield Advanced should configure its WAF rules with the WAF <code>Block</code>
        /// action. </para><para>You must specify exactly one action, either <code>Block</code> or <code>Count</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Shield.Model.BlockAction Action_Block { get; set; }
        #endregion
        
        #region Parameter Action_Count
        /// <summary>
        /// <para>
        /// <para>Specifies that Shield Advanced should configure its WAF rules with the WAF <code>Count</code>
        /// action. </para><para>You must specify exactly one action, either <code>Block</code> or <code>Count</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Shield.Model.CountAction Action_Count { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The ARN (Amazon Resource Name) of the protected resource.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Shield.Model.EnableApplicationLayerAutomaticResponseResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-SHLDApplicationLayerAutomaticResponse (EnableApplicationLayerAutomaticResponse)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Shield.Model.EnableApplicationLayerAutomaticResponseResponse, EnableSHLDApplicationLayerAutomaticResponseCmdlet>(Select) ??
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
            var request = new Amazon.Shield.Model.EnableApplicationLayerAutomaticResponseRequest();
            
            
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
        
        private Amazon.Shield.Model.EnableApplicationLayerAutomaticResponseResponse CallAWSServiceOperation(IAmazonShield client, Amazon.Shield.Model.EnableApplicationLayerAutomaticResponseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Shield", "EnableApplicationLayerAutomaticResponse");
            try
            {
                #if DESKTOP
                return client.EnableApplicationLayerAutomaticResponse(request);
                #elif CORECLR
                return client.EnableApplicationLayerAutomaticResponseAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Shield.Model.EnableApplicationLayerAutomaticResponseResponse, EnableSHLDApplicationLayerAutomaticResponseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}

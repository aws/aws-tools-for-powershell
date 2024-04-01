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
using Amazon.DataZone;
using Amazon.DataZone.Model;

namespace Amazon.PowerShell.Cmdlets.DZ
{
    /// <summary>
    /// Accepts automatically generated business-friendly metadata for your Amazon DataZone
    /// assets.
    /// </summary>
    [Cmdlet("Approve", "DZPrediction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DataZone.Model.AcceptPredictionsResponse")]
    [AWSCmdlet("Calls the Amazon DataZone AcceptPredictions API operation.", Operation = new[] {"AcceptPredictions"}, SelectReturnType = typeof(Amazon.DataZone.Model.AcceptPredictionsResponse))]
    [AWSCmdletOutput("Amazon.DataZone.Model.AcceptPredictionsResponse",
        "This cmdlet returns an Amazon.DataZone.Model.AcceptPredictionsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ApproveDZPredictionCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AcceptChoice
        /// <summary>
        /// <para>
        /// <para>Specifies the prediction (aka, the automatically generated piece of metadata) and
        /// the target (for example, a column name) that can be accepted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AcceptChoices")]
        public Amazon.DataZone.Model.AcceptChoice[] AcceptChoice { get; set; }
        #endregion
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon DataZone domain.</para>
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
        public System.String DomainIdentifier { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the asset.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter Revision
        /// <summary>
        /// <para>
        /// <para>The revision that is to be made to the asset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Revision { get; set; }
        #endregion
        
        #region Parameter AcceptRule_Rule
        /// <summary>
        /// <para>
        /// <para>Specifies whether you want to accept the top prediction for all targets or none.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataZone.AcceptRuleBehavior")]
        public Amazon.DataZone.AcceptRuleBehavior AcceptRule_Rule { get; set; }
        #endregion
        
        #region Parameter AcceptRule_Threshold
        /// <summary>
        /// <para>
        /// <para>The confidence score that specifies the condition at which a prediction can be accepted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? AcceptRule_Threshold { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure idempotency of the request. This field
        /// is automatically populated if not provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.AcceptPredictionsResponse).
        /// Specifying the name of a property of type Amazon.DataZone.Model.AcceptPredictionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Identifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Approve-DZPrediction (AcceptPredictions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.AcceptPredictionsResponse, ApproveDZPredictionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Identifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AcceptChoice != null)
            {
                context.AcceptChoice = new List<Amazon.DataZone.Model.AcceptChoice>(this.AcceptChoice);
            }
            context.AcceptRule_Rule = this.AcceptRule_Rule;
            context.AcceptRule_Threshold = this.AcceptRule_Threshold;
            context.ClientToken = this.ClientToken;
            context.DomainIdentifier = this.DomainIdentifier;
            #if MODULAR
            if (this.DomainIdentifier == null && ParameterWasBound(nameof(this.DomainIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Revision = this.Revision;
            
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
            var request = new Amazon.DataZone.Model.AcceptPredictionsRequest();
            
            if (cmdletContext.AcceptChoice != null)
            {
                request.AcceptChoices = cmdletContext.AcceptChoice;
            }
            
             // populate AcceptRule
            var requestAcceptRuleIsNull = true;
            request.AcceptRule = new Amazon.DataZone.Model.AcceptRule();
            Amazon.DataZone.AcceptRuleBehavior requestAcceptRule_acceptRule_Rule = null;
            if (cmdletContext.AcceptRule_Rule != null)
            {
                requestAcceptRule_acceptRule_Rule = cmdletContext.AcceptRule_Rule;
            }
            if (requestAcceptRule_acceptRule_Rule != null)
            {
                request.AcceptRule.Rule = requestAcceptRule_acceptRule_Rule;
                requestAcceptRuleIsNull = false;
            }
            System.Single? requestAcceptRule_acceptRule_Threshold = null;
            if (cmdletContext.AcceptRule_Threshold != null)
            {
                requestAcceptRule_acceptRule_Threshold = cmdletContext.AcceptRule_Threshold.Value;
            }
            if (requestAcceptRule_acceptRule_Threshold != null)
            {
                request.AcceptRule.Threshold = requestAcceptRule_acceptRule_Threshold.Value;
                requestAcceptRuleIsNull = false;
            }
             // determine if request.AcceptRule should be set to null
            if (requestAcceptRuleIsNull)
            {
                request.AcceptRule = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DomainIdentifier != null)
            {
                request.DomainIdentifier = cmdletContext.DomainIdentifier;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.Revision != null)
            {
                request.Revision = cmdletContext.Revision;
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
        
        private Amazon.DataZone.Model.AcceptPredictionsResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.AcceptPredictionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "AcceptPredictions");
            try
            {
                #if DESKTOP
                return client.AcceptPredictions(request);
                #elif CORECLR
                return client.AcceptPredictionsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.DataZone.Model.AcceptChoice> AcceptChoice { get; set; }
            public Amazon.DataZone.AcceptRuleBehavior AcceptRule_Rule { get; set; }
            public System.Single? AcceptRule_Threshold { get; set; }
            public System.String ClientToken { get; set; }
            public System.String DomainIdentifier { get; set; }
            public System.String Identifier { get; set; }
            public System.String Revision { get; set; }
            public System.Func<Amazon.DataZone.Model.AcceptPredictionsResponse, ApproveDZPredictionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

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
using Amazon.LexModelsV2;
using Amazon.LexModelsV2.Model;

namespace Amazon.PowerShell.Cmdlets.LMBV2
{
    /// <summary>
    /// The action to start test set execution.
    /// </summary>
    [Cmdlet("Start", "LMBV2TestExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LexModelsV2.Model.StartTestExecutionResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building V2 StartTestExecution API operation.", Operation = new[] {"StartTestExecution"}, SelectReturnType = typeof(Amazon.LexModelsV2.Model.StartTestExecutionResponse))]
    [AWSCmdletOutput("Amazon.LexModelsV2.Model.StartTestExecutionResponse",
        "This cmdlet returns an Amazon.LexModelsV2.Model.StartTestExecutionResponse object containing multiple properties."
    )]
    public partial class StartLMBV2TestExecutionCmdlet : AmazonLexModelsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApiMode
        /// <summary>
        /// <para>
        /// <para>Indicates whether we use streaming or non-streaming APIs for the test set execution.
        /// For streaming, StartConversation Runtime API is used. Whereas, for non-streaming,
        /// RecognizeUtterance and RecognizeText Amazon Lex Runtime API are used.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.LexModelsV2.TestExecutionApiMode")]
        public Amazon.LexModelsV2.TestExecutionApiMode ApiMode { get; set; }
        #endregion
        
        #region Parameter BotAliasTarget_BotAliasId
        /// <summary>
        /// <para>
        /// <para>The bot alias Id of the bot alias used in the test set execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_BotAliasTarget_BotAliasId")]
        public System.String BotAliasTarget_BotAliasId { get; set; }
        #endregion
        
        #region Parameter BotAliasTarget_BotId
        /// <summary>
        /// <para>
        /// <para>The bot Id of the bot alias used in the test set execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_BotAliasTarget_BotId")]
        public System.String BotAliasTarget_BotId { get; set; }
        #endregion
        
        #region Parameter BotAliasTarget_LocaleId
        /// <summary>
        /// <para>
        /// <para>The locale Id of the bot alias used in the test set execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Target_BotAliasTarget_LocaleId")]
        public System.String BotAliasTarget_LocaleId { get; set; }
        #endregion
        
        #region Parameter TestExecutionModality
        /// <summary>
        /// <para>
        /// <para>Indicates whether audio or text is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LexModelsV2.TestExecutionModality")]
        public Amazon.LexModelsV2.TestExecutionModality TestExecutionModality { get; set; }
        #endregion
        
        #region Parameter TestSetId
        /// <summary>
        /// <para>
        /// <para>The test set Id for the test set execution.</para>
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
        public System.String TestSetId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelsV2.Model.StartTestExecutionResponse).
        /// Specifying the name of a property of type Amazon.LexModelsV2.Model.StartTestExecutionResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TestSetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-LMBV2TestExecution (StartTestExecution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexModelsV2.Model.StartTestExecutionResponse, StartLMBV2TestExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApiMode = this.ApiMode;
            #if MODULAR
            if (this.ApiMode == null && ParameterWasBound(nameof(this.ApiMode)))
            {
                WriteWarning("You are passing $null as a value for parameter ApiMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BotAliasTarget_BotAliasId = this.BotAliasTarget_BotAliasId;
            context.BotAliasTarget_BotId = this.BotAliasTarget_BotId;
            context.BotAliasTarget_LocaleId = this.BotAliasTarget_LocaleId;
            context.TestExecutionModality = this.TestExecutionModality;
            context.TestSetId = this.TestSetId;
            #if MODULAR
            if (this.TestSetId == null && ParameterWasBound(nameof(this.TestSetId)))
            {
                WriteWarning("You are passing $null as a value for parameter TestSetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LexModelsV2.Model.StartTestExecutionRequest();
            
            if (cmdletContext.ApiMode != null)
            {
                request.ApiMode = cmdletContext.ApiMode;
            }
            
             // populate Target
            var requestTargetIsNull = true;
            request.Target = new Amazon.LexModelsV2.Model.TestExecutionTarget();
            Amazon.LexModelsV2.Model.BotAliasTestExecutionTarget requestTarget_target_BotAliasTarget = null;
            
             // populate BotAliasTarget
            var requestTarget_target_BotAliasTargetIsNull = true;
            requestTarget_target_BotAliasTarget = new Amazon.LexModelsV2.Model.BotAliasTestExecutionTarget();
            System.String requestTarget_target_BotAliasTarget_botAliasTarget_BotAliasId = null;
            if (cmdletContext.BotAliasTarget_BotAliasId != null)
            {
                requestTarget_target_BotAliasTarget_botAliasTarget_BotAliasId = cmdletContext.BotAliasTarget_BotAliasId;
            }
            if (requestTarget_target_BotAliasTarget_botAliasTarget_BotAliasId != null)
            {
                requestTarget_target_BotAliasTarget.BotAliasId = requestTarget_target_BotAliasTarget_botAliasTarget_BotAliasId;
                requestTarget_target_BotAliasTargetIsNull = false;
            }
            System.String requestTarget_target_BotAliasTarget_botAliasTarget_BotId = null;
            if (cmdletContext.BotAliasTarget_BotId != null)
            {
                requestTarget_target_BotAliasTarget_botAliasTarget_BotId = cmdletContext.BotAliasTarget_BotId;
            }
            if (requestTarget_target_BotAliasTarget_botAliasTarget_BotId != null)
            {
                requestTarget_target_BotAliasTarget.BotId = requestTarget_target_BotAliasTarget_botAliasTarget_BotId;
                requestTarget_target_BotAliasTargetIsNull = false;
            }
            System.String requestTarget_target_BotAliasTarget_botAliasTarget_LocaleId = null;
            if (cmdletContext.BotAliasTarget_LocaleId != null)
            {
                requestTarget_target_BotAliasTarget_botAliasTarget_LocaleId = cmdletContext.BotAliasTarget_LocaleId;
            }
            if (requestTarget_target_BotAliasTarget_botAliasTarget_LocaleId != null)
            {
                requestTarget_target_BotAliasTarget.LocaleId = requestTarget_target_BotAliasTarget_botAliasTarget_LocaleId;
                requestTarget_target_BotAliasTargetIsNull = false;
            }
             // determine if requestTarget_target_BotAliasTarget should be set to null
            if (requestTarget_target_BotAliasTargetIsNull)
            {
                requestTarget_target_BotAliasTarget = null;
            }
            if (requestTarget_target_BotAliasTarget != null)
            {
                request.Target.BotAliasTarget = requestTarget_target_BotAliasTarget;
                requestTargetIsNull = false;
            }
             // determine if request.Target should be set to null
            if (requestTargetIsNull)
            {
                request.Target = null;
            }
            if (cmdletContext.TestExecutionModality != null)
            {
                request.TestExecutionModality = cmdletContext.TestExecutionModality;
            }
            if (cmdletContext.TestSetId != null)
            {
                request.TestSetId = cmdletContext.TestSetId;
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
        
        private Amazon.LexModelsV2.Model.StartTestExecutionResponse CallAWSServiceOperation(IAmazonLexModelsV2 client, Amazon.LexModelsV2.Model.StartTestExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building V2", "StartTestExecution");
            try
            {
                #if DESKTOP
                return client.StartTestExecution(request);
                #elif CORECLR
                return client.StartTestExecutionAsync(request).GetAwaiter().GetResult();
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
            public Amazon.LexModelsV2.TestExecutionApiMode ApiMode { get; set; }
            public System.String BotAliasTarget_BotAliasId { get; set; }
            public System.String BotAliasTarget_BotId { get; set; }
            public System.String BotAliasTarget_LocaleId { get; set; }
            public Amazon.LexModelsV2.TestExecutionModality TestExecutionModality { get; set; }
            public System.String TestSetId { get; set; }
            public System.Func<Amazon.LexModelsV2.Model.StartTestExecutionResponse, StartLMBV2TestExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

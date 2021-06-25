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
using Amazon.LexModelBuildingService;
using Amazon.LexModelBuildingService.Model;

namespace Amazon.PowerShell.Cmdlets.LMB
{
    /// <summary>
    /// Use the <code>GetUtterancesView</code> operation to get information about the utterances
    /// that your users have made to your bot. You can use this list to tune the utterances
    /// that your bot responds to.
    /// 
    ///  
    /// <para>
    /// For example, say that you have created a bot to order flowers. After your users have
    /// used your bot for a while, use the <code>GetUtterancesView</code> operation to see
    /// the requests that they have made and whether they have been successful. You might
    /// find that the utterance "I want flowers" is not being recognized. You could add this
    /// utterance to the <code>OrderFlowers</code> intent so that your bot recognizes that
    /// utterance.
    /// </para><para>
    /// After you publish a new version of a bot, you can get information about the old version
    /// and the new so that you can compare the performance across the two versions. 
    /// </para><para>
    /// Utterance statistics are generated once a day. Data is available for the last 15 days.
    /// You can request information for up to 5 versions of your bot in each request. Amazon
    /// Lex returns the most frequent utterances received by the bot in the last 15 days.
    /// The response contains information about a maximum of 100 utterances for each version.
    /// </para><para>
    /// If you set <code>childDirected</code> field to true when you created your bot, if
    /// you are using slot obfuscation with one or more slots, or if you opted out of participating
    /// in improving Amazon Lex, utterances are not available.
    /// </para><para>
    /// This operation requires permissions for the <code>lex:GetUtterancesView</code> action.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "LMBUtterancesView")]
    [OutputType("Amazon.LexModelBuildingService.Model.GetUtterancesViewResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building Service GetUtterancesView API operation.", Operation = new[] {"GetUtterancesView"}, SelectReturnType = typeof(Amazon.LexModelBuildingService.Model.GetUtterancesViewResponse))]
    [AWSCmdletOutput("Amazon.LexModelBuildingService.Model.GetUtterancesViewResponse",
        "This cmdlet returns an Amazon.LexModelBuildingService.Model.GetUtterancesViewResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetLMBUtterancesViewCmdlet : AmazonLexModelBuildingServiceClientCmdlet, IExecutor
    {
        
        #region Parameter BotName
        /// <summary>
        /// <para>
        /// <para>The name of the bot for which utterance information should be returned.</para>
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
        public System.String BotName { get; set; }
        #endregion
        
        #region Parameter BotVersion
        /// <summary>
        /// <para>
        /// <para>An array of bot versions for which utterance information should be returned. The limit
        /// is 5 versions per request.</para>
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
        [Alias("BotVersions")]
        public System.String[] BotVersion { get; set; }
        #endregion
        
        #region Parameter StatusType
        /// <summary>
        /// <para>
        /// <para>To return utterances that were recognized and handled, use <code>Detected</code>.
        /// To return utterances that were not recognized, use <code>Missed</code>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.LexModelBuildingService.StatusType")]
        public Amazon.LexModelBuildingService.StatusType StatusType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LexModelBuildingService.Model.GetUtterancesViewResponse).
        /// Specifying the name of a property of type Amazon.LexModelBuildingService.Model.GetUtterancesViewResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BotName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BotName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BotName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LexModelBuildingService.Model.GetUtterancesViewResponse, GetLMBUtterancesViewCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BotName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BotName = this.BotName;
            #if MODULAR
            if (this.BotName == null && ParameterWasBound(nameof(this.BotName)))
            {
                WriteWarning("You are passing $null as a value for parameter BotName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.BotVersion != null)
            {
                context.BotVersion = new List<System.String>(this.BotVersion);
            }
            #if MODULAR
            if (this.BotVersion == null && ParameterWasBound(nameof(this.BotVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter BotVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StatusType = this.StatusType;
            #if MODULAR
            if (this.StatusType == null && ParameterWasBound(nameof(this.StatusType)))
            {
                WriteWarning("You are passing $null as a value for parameter StatusType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LexModelBuildingService.Model.GetUtterancesViewRequest();
            
            if (cmdletContext.BotName != null)
            {
                request.BotName = cmdletContext.BotName;
            }
            if (cmdletContext.BotVersion != null)
            {
                request.BotVersions = cmdletContext.BotVersion;
            }
            if (cmdletContext.StatusType != null)
            {
                request.StatusType = cmdletContext.StatusType;
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
        
        private Amazon.LexModelBuildingService.Model.GetUtterancesViewResponse CallAWSServiceOperation(IAmazonLexModelBuildingService client, Amazon.LexModelBuildingService.Model.GetUtterancesViewRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building Service", "GetUtterancesView");
            try
            {
                #if DESKTOP
                return client.GetUtterancesView(request);
                #elif CORECLR
                return client.GetUtterancesViewAsync(request).GetAwaiter().GetResult();
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
            public System.String BotName { get; set; }
            public List<System.String> BotVersion { get; set; }
            public Amazon.LexModelBuildingService.StatusType StatusType { get; set; }
            public System.Func<Amazon.LexModelBuildingService.Model.GetUtterancesViewResponse, GetLMBUtterancesViewCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Data is available for the last 15 days. You can request information for up to 5 versions
    /// in each request. The response contains information about a maximum of 100 utterances
    /// for each version.
    /// </para><para>
    /// If the bot's <code>childDirected</code> field is set to <code>true</code>, utterances
    /// for the bot are not stored and cannot be retrieved with the <code>GetUtterancesView</code>
    /// operation. For more information, see .
    /// </para><para>
    /// This operation requires permissions for the <code>lex:GetUtterancesView</code> action.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "LMBUtterancesView")]
    [OutputType("Amazon.LexModelBuildingService.Model.GetUtterancesViewResponse")]
    [AWSCmdlet("Invokes the GetUtterancesView operation against Amazon Lex Model Building Service.", Operation = new[] {"GetUtterancesView"})]
    [AWSCmdletOutput("Amazon.LexModelBuildingService.Model.GetUtterancesViewResponse",
        "This cmdlet returns a Amazon.LexModelBuildingService.Model.GetUtterancesViewResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetLMBUtterancesViewCmdlet : AmazonLexModelBuildingServiceClientCmdlet, IExecutor
    {
        
        #region Parameter BotName
        /// <summary>
        /// <para>
        /// <para>The name of the bot for which utterance information should be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String BotName { get; set; }
        #endregion
        
        #region Parameter BotVersion
        /// <summary>
        /// <para>
        /// <para>An array of bot versions for which utterance information should be returned. The limit
        /// is 5 versions per request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("BotVersions")]
        public System.String[] BotVersion { get; set; }
        #endregion
        
        #region Parameter StatusType
        /// <summary>
        /// <para>
        /// <para>To return utterances that were recognized and handled, use<code>Detected</code>. To
        /// return utterances that were not recognized, use <code>Missed</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.LexModelBuildingService.StatusType")]
        public Amazon.LexModelBuildingService.StatusType StatusType { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.BotName = this.BotName;
            if (this.BotVersion != null)
            {
                context.BotVersions = new List<System.String>(this.BotVersion);
            }
            context.StatusType = this.StatusType;
            
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
            if (cmdletContext.BotVersions != null)
            {
                request.BotVersions = cmdletContext.BotVersions;
            }
            if (cmdletContext.StatusType != null)
            {
                request.StatusType = cmdletContext.StatusType;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
            #if DESKTOP
            return client.GetUtterancesView(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.GetUtterancesViewAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String BotName { get; set; }
            public List<System.String> BotVersions { get; set; }
            public Amazon.LexModelBuildingService.StatusType StatusType { get; set; }
        }
        
    }
}

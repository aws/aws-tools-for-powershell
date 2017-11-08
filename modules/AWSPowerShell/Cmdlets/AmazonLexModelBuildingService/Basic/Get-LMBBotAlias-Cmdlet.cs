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
    /// Returns information about an Amazon Lex bot alias. For more information about aliases,
    /// see <a>versioning-aliases</a>.
    /// 
    ///  
    /// <para>
    /// This operation requires permissions for the <code>lex:GetBotAlias</code> action.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "LMBBotAlias")]
    [OutputType("Amazon.LexModelBuildingService.Model.GetBotAliasResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building Service GetBotAlias API operation.", Operation = new[] {"GetBotAlias"})]
    [AWSCmdletOutput("Amazon.LexModelBuildingService.Model.GetBotAliasResponse",
        "This cmdlet returns a Amazon.LexModelBuildingService.Model.GetBotAliasResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetLMBBotAliasCmdlet : AmazonLexModelBuildingServiceClientCmdlet, IExecutor
    {
        
        #region Parameter BotName
        /// <summary>
        /// <para>
        /// <para>The name of the bot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BotName { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the bot alias. The name is case sensitive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
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
            context.Name = this.Name;
            
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
            var request = new Amazon.LexModelBuildingService.Model.GetBotAliasRequest();
            
            if (cmdletContext.BotName != null)
            {
                request.BotName = cmdletContext.BotName;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.LexModelBuildingService.Model.GetBotAliasResponse CallAWSServiceOperation(IAmazonLexModelBuildingService client, Amazon.LexModelBuildingService.Model.GetBotAliasRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building Service", "GetBotAlias");
            try
            {
                #if DESKTOP
                return client.GetBotAlias(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetBotAliasAsync(request);
                return task.Result;
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
            public System.String Name { get; set; }
        }
        
    }
}

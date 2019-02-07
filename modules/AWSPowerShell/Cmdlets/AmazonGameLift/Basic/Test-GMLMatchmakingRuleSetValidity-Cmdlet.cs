/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.GameLift;
using Amazon.GameLift.Model;

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// Validates the syntax of a matchmaking rule or rule set. This operation checks that
    /// the rule set is using syntactically correct JSON and that it conforms to allowed property
    /// expressions. To validate syntax, provide a rule set JSON string.
    /// 
    ///  
    /// <para><b>Learn more</b></para><ul><li><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/match-rulesets.html">Build
    /// a Rule Set</a></para></li></ul><para><b>Related operations</b></para><ul><li><para><a>CreateMatchmakingConfiguration</a></para></li><li><para><a>DescribeMatchmakingConfigurations</a></para></li><li><para><a>UpdateMatchmakingConfiguration</a></para></li><li><para><a>DeleteMatchmakingConfiguration</a></para></li><li><para><a>CreateMatchmakingRuleSet</a></para></li><li><para><a>DescribeMatchmakingRuleSets</a></para></li><li><para><a>ValidateMatchmakingRuleSet</a></para></li><li><para><a>DeleteMatchmakingRuleSet</a></para></li></ul>
    /// </summary>
    [Cmdlet("Test", "GMLMatchmakingRuleSetValidity")]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon GameLift Service ValidateMatchmakingRuleSet API operation.", Operation = new[] {"ValidateMatchmakingRuleSet"})]
    [AWSCmdletOutput("System.Boolean",
        "This cmdlet returns a Boolean object.",
        "The service call response (type Amazon.GameLift.Model.ValidateMatchmakingRuleSetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class TestGMLMatchmakingRuleSetValidityCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter RuleSetBody
        /// <summary>
        /// <para>
        /// <para>Collection of matchmaking rules to validate, formatted as a JSON string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String RuleSetBody { get; set; }
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
            
            context.RuleSetBody = this.RuleSetBody;
            
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
            var request = new Amazon.GameLift.Model.ValidateMatchmakingRuleSetRequest();
            
            if (cmdletContext.RuleSetBody != null)
            {
                request.RuleSetBody = cmdletContext.RuleSetBody;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Valid;
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
        
        private Amazon.GameLift.Model.ValidateMatchmakingRuleSetResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.ValidateMatchmakingRuleSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "ValidateMatchmakingRuleSet");
            try
            {
                #if DESKTOP
                return client.ValidateMatchmakingRuleSet(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ValidateMatchmakingRuleSetAsync(request);
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
            public System.String RuleSetBody { get; set; }
        }
        
    }
}

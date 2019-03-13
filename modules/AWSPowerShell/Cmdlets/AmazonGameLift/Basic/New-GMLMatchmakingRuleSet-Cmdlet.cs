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
    /// Creates a new rule set for FlexMatch matchmaking. A rule set describes the type of
    /// match to create, such as the number and size of teams, and sets the parameters for
    /// acceptable player matches, such as minimum skill level or character type. A rule set
    /// is used by a <a>MatchmakingConfiguration</a>. 
    /// 
    ///  
    /// <para>
    /// To create a matchmaking rule set, provide unique rule set name and the rule set body
    /// in JSON format. Rule sets must be defined in the same region as the matchmaking configuration
    /// they will be used with.
    /// </para><para>
    /// Since matchmaking rule sets cannot be edited, it is a good idea to check the rule
    /// set syntax using <a>ValidateMatchmakingRuleSet</a> before creating a new rule set.
    /// </para><para><b>Learn more</b></para><ul><li><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/match-rulesets.html">Build
    /// a Rule Set</a></para></li><li><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/match-configuration.html">Design
    /// a Matchmaker</a></para></li><li><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/match-intro.html">Matchmaking
    /// with FlexMatch</a></para></li></ul><para><b>Related operations</b></para><ul><li><para><a>CreateMatchmakingConfiguration</a></para></li><li><para><a>DescribeMatchmakingConfigurations</a></para></li><li><para><a>UpdateMatchmakingConfiguration</a></para></li><li><para><a>DeleteMatchmakingConfiguration</a></para></li><li><para><a>CreateMatchmakingRuleSet</a></para></li><li><para><a>DescribeMatchmakingRuleSets</a></para></li><li><para><a>ValidateMatchmakingRuleSet</a></para></li><li><para><a>DeleteMatchmakingRuleSet</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "GMLMatchmakingRuleSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.MatchmakingRuleSet")]
    [AWSCmdlet("Calls the Amazon GameLift Service CreateMatchmakingRuleSet API operation.", Operation = new[] {"CreateMatchmakingRuleSet"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.MatchmakingRuleSet",
        "This cmdlet returns a MatchmakingRuleSet object.",
        "The service call response (type Amazon.GameLift.Model.CreateMatchmakingRuleSetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGMLMatchmakingRuleSetCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a matchmaking rule set. A matchmaking configuration identifies
        /// the rule set it uses by this name value. (Note: The rule set name is different from
        /// the optional "name" field in the rule set body.) </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RuleSetBody
        /// <summary>
        /// <para>
        /// <para>Collection of matchmaking rules, formatted as a JSON string. Note that comments are
        /// not allowed in JSON, but most elements support a description field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RuleSetBody { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GMLMatchmakingRuleSet (CreateMatchmakingRuleSet)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Name = this.Name;
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
            var request = new Amazon.GameLift.Model.CreateMatchmakingRuleSetRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
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
                object pipelineOutput = response.RuleSet;
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
        
        private Amazon.GameLift.Model.CreateMatchmakingRuleSetResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.CreateMatchmakingRuleSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "CreateMatchmakingRuleSet");
            try
            {
                #if DESKTOP
                return client.CreateMatchmakingRuleSet(request);
                #elif CORECLR
                return client.CreateMatchmakingRuleSetAsync(request).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public System.String RuleSetBody { get; set; }
        }
        
    }
}

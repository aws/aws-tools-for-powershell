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
using Amazon.GameLift;
using Amazon.GameLift.Model;

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// Creates a new rule set for FlexMatch matchmaking. A rule set describes the type of
    /// match to create, such as the number and size of teams. It also sets the parameters
    /// for acceptable player matches, such as minimum skill level or character type.
    /// 
    ///  
    /// <para>
    /// To create a matchmaking rule set, provide unique rule set name and the rule set body
    /// in JSON format. Rule sets must be defined in the same Region as the matchmaking configuration
    /// they are used with.
    /// </para><para>
    /// Since matchmaking rule sets cannot be edited, it is a good idea to check the rule
    /// set syntax using <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_ValidateMatchmakingRuleSet.html">ValidateMatchmakingRuleSet</a>
    /// before creating a new rule set.
    /// </para><para><b>Learn more</b></para><ul><li><para><a href="https://docs.aws.amazon.com/gamelift/latest/flexmatchguide/match-rulesets.html">Build
    /// a rule set</a></para></li><li><para><a href="https://docs.aws.amazon.com/gamelift/latest/flexmatchguide/match-configuration.html">Design
    /// a matchmaker</a></para></li><li><para><a href="https://docs.aws.amazon.com/gamelift/latest/flexmatchguide/match-intro.html">Matchmaking
    /// with FlexMatch</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "GMLMatchmakingRuleSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.MatchmakingRuleSet")]
    [AWSCmdlet("Calls the Amazon GameLift Service CreateMatchmakingRuleSet API operation.", Operation = new[] {"CreateMatchmakingRuleSet"}, SelectReturnType = typeof(Amazon.GameLift.Model.CreateMatchmakingRuleSetResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.MatchmakingRuleSet or Amazon.GameLift.Model.CreateMatchmakingRuleSetResponse",
        "This cmdlet returns an Amazon.GameLift.Model.MatchmakingRuleSet object.",
        "The service call response (type Amazon.GameLift.Model.CreateMatchmakingRuleSetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewGMLMatchmakingRuleSetCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the matchmaking rule set. A matchmaking configuration identifies
        /// the rule set it uses by this name value. Note that the rule set name is different
        /// from the optional <c>name</c> field in the rule set body.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RuleSetBody
        /// <summary>
        /// <para>
        /// <para>A collection of matchmaking rules, formatted as a JSON string. Comments are not allowed
        /// in JSON, but most elements support a description field.</para>
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
        public System.String RuleSetBody { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of labels to assign to the new matchmaking rule set resource. Tags are developer-defined
        /// key-value pairs. Tagging Amazon Web Services resources are useful for resource management,
        /// access management and cost allocation. For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">
        /// Tagging Amazon Web Services Resources</a> in the <i>Amazon Web Services General Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.GameLift.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RuleSet'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.CreateMatchmakingRuleSetResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.CreateMatchmakingRuleSetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RuleSet";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GMLMatchmakingRuleSet (CreateMatchmakingRuleSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.CreateMatchmakingRuleSetResponse, NewGMLMatchmakingRuleSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleSetBody = this.RuleSetBody;
            #if MODULAR
            if (this.RuleSetBody == null && ParameterWasBound(nameof(this.RuleSetBody)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleSetBody which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.GameLift.Model.Tag>(this.Tag);
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
            var request = new Amazon.GameLift.Model.CreateMatchmakingRuleSetRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RuleSetBody != null)
            {
                request.RuleSetBody = cmdletContext.RuleSetBody;
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
            public List<Amazon.GameLift.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.GameLift.Model.CreateMatchmakingRuleSetResponse, NewGMLMatchmakingRuleSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RuleSet;
        }
        
    }
}

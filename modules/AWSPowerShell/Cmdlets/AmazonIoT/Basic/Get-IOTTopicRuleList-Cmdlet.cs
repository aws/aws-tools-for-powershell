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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Lists the rules for the specific topic.
    /// </summary>
    [Cmdlet("Get", "IOTTopicRuleList")]
    [OutputType("Amazon.IoT.Model.TopicRuleListItem")]
    [AWSCmdlet("Invokes the ListTopicRules operation against AWS IoT.", Operation = new[] {"ListTopicRules"})]
    [AWSCmdletOutput("Amazon.IoT.Model.TopicRuleListItem",
        "This cmdlet returns a collection of TopicRuleListItem objects.",
        "The service call response (type ListTopicRulesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextMarker (type String)"
    )]
    public class GetIOTTopicRuleListCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Specifies whether the rule is disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean RuleDisabled { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String Topic { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A token used to retrieve the next value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public String Marker { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxResults")]
        public Int32 MaxResult { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Marker = this.Marker;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            if (ParameterWasBound("RuleDisabled"))
                context.RuleDisabled = this.RuleDisabled;
            context.Topic = this.Topic;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new ListTopicRulesRequest();
            
            if (cmdletContext.Marker != null)
            {
                request.Marker = cmdletContext.Marker;
            }
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = cmdletContext.MaxResults.Value;
            }
            if (cmdletContext.RuleDisabled != null)
            {
                request.RuleDisabled = cmdletContext.RuleDisabled.Value;
            }
            if (cmdletContext.Topic != null)
            {
                request.Topic = cmdletContext.Topic;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ListTopicRules(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Rules;
                notes = new Dictionary<string, object>();
                notes["NextMarker"] = response.NextMarker;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String Marker { get; set; }
            public Int32? MaxResults { get; set; }
            public Boolean? RuleDisabled { get; set; }
            public String Topic { get; set; }
        }
        
    }
}

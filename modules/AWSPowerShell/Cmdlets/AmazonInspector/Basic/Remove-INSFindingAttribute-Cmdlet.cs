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
using Amazon.Inspector;
using Amazon.Inspector.Model;

namespace Amazon.PowerShell.Cmdlets.INS
{
    /// <summary>
    /// Removes the entire attribute (key and value pair) from the findings specified by the
    /// finding ARNs where an attribute with the specified key exists.
    /// </summary>
    [Cmdlet("Remove", "INSFindingAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the RemoveAttributesFromFindings operation against Amazon Inspector.", Operation = new[] {"RemoveAttributesFromFindings"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.Inspector.Model.RemoveAttributesFromFindingsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RemoveINSFindingAttributeCmdlet : AmazonInspectorClientCmdlet, IExecutor
    {
        
        #region Parameter AttributeKey
        /// <summary>
        /// <para>
        /// <para>The array of attribute keys that you want to remove from specified findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AttributeKeys")]
        public System.String[] AttributeKey { get; set; }
        #endregion
        
        #region Parameter FindingArn
        /// <summary>
        /// <para>
        /// <para>The ARNs specifying the findings that you want to remove attributes from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("FindingArns")]
        public System.String[] FindingArn { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("FindingArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-INSFindingAttribute (RemoveAttributesFromFindings)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.AttributeKey != null)
            {
                context.AttributeKeys = new List<System.String>(this.AttributeKey);
            }
            if (this.FindingArn != null)
            {
                context.FindingArns = new List<System.String>(this.FindingArn);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Inspector.Model.RemoveAttributesFromFindingsRequest();
            
            if (cmdletContext.AttributeKeys != null)
            {
                request.AttributeKeys = cmdletContext.AttributeKeys;
            }
            if (cmdletContext.FindingArns != null)
            {
                request.FindingArns = cmdletContext.FindingArns;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.RemoveAttributesFromFindings(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Message;
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
            public List<System.String> AttributeKeys { get; set; }
            public List<System.String> FindingArns { get; set; }
        }
        
    }
}

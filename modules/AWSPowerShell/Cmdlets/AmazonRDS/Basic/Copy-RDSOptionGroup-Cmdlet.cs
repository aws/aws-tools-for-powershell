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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Copies the specified option group.
    /// </summary>
    [Cmdlet("Copy", "RDSOptionGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.OptionGroup")]
    [AWSCmdlet("Invokes the CopyOptionGroup operation against Amazon Relational Database Service.", Operation = new[] {"CopyOptionGroup"})]
    [AWSCmdletOutput("Amazon.RDS.Model.OptionGroup",
        "This cmdlet returns a OptionGroup object.",
        "The service call response (type Amazon.RDS.Model.CopyOptionGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class CopyRDSOptionGroupCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The identifier or ARN for the source option group. For information about creating
        /// an ARN, see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_Tagging.html#USER_Tagging.ARN">
        /// Constructing an RDS Amazon Resource Name (ARN)</a>. </para><para>Constraints:</para><ul><li>Must specify a valid option group.</li><li>If the source option group is
        /// in the same region as the copy, specify a valid option group identifier, for example
        /// <code>my-option-group</code>, or a valid ARN.</li><li>If the source option group
        /// is in a different region than the copy, specify a valid option group ARN, for example
        /// <code>arn:aws:rds:us-west-2:123456789012:og:special-options</code>.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SourceOptionGroupIdentifier { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The description for the copied option group. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String TargetOptionGroupDescription { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The identifier for the copied option group. </para><para>Constraints:</para><ul><li>Cannot be null, empty, or blank</li><li>Must contain from 1 to 255 alphanumeric
        /// characters or hyphens</li><li>First character must be a letter</li><li>Cannot end
        /// with a hyphen or contain two consecutive hyphens</li></ul><para>Example: <code>my-option-group</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String TargetOptionGroupIdentifier { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SourceOptionGroupIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-RDSOptionGroup (CopyOptionGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.SourceOptionGroupIdentifier = this.SourceOptionGroupIdentifier;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.RDS.Model.Tag>(this.Tag);
            }
            context.TargetOptionGroupDescription = this.TargetOptionGroupDescription;
            context.TargetOptionGroupIdentifier = this.TargetOptionGroupIdentifier;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.RDS.Model.CopyOptionGroupRequest();
            
            if (cmdletContext.SourceOptionGroupIdentifier != null)
            {
                request.SourceOptionGroupIdentifier = cmdletContext.SourceOptionGroupIdentifier;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.TargetOptionGroupDescription != null)
            {
                request.TargetOptionGroupDescription = cmdletContext.TargetOptionGroupDescription;
            }
            if (cmdletContext.TargetOptionGroupIdentifier != null)
            {
                request.TargetOptionGroupIdentifier = cmdletContext.TargetOptionGroupIdentifier;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CopyOptionGroup(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.OptionGroup;
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
            public System.String SourceOptionGroupIdentifier { get; set; }
            public List<Amazon.RDS.Model.Tag> Tags { get; set; }
            public System.String TargetOptionGroupDescription { get; set; }
            public System.String TargetOptionGroupIdentifier { get; set; }
        }
        
    }
}

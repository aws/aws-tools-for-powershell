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
    /// Copies the specified DB parameter group.
    /// </summary>
    [Cmdlet("Copy", "RDSDBParameterGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBParameterGroup")]
    [AWSCmdlet("Invokes the CopyDBParameterGroup operation against Amazon Relational Database Service.", Operation = new[] {"CopyDBParameterGroup"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBParameterGroup",
        "This cmdlet returns a DBParameterGroup object.",
        "The service call response (type CopyDBParameterGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class CopyRDSDBParameterGroupCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> The identifier or ARN for the source DB parameter group. </para><para>Constraints:</para><ul><li>Must specify a valid DB parameter group.</li><li>If the source DB parameter
        /// group is in the same region as the copy, specify a valid DB parameter group identifier,
        /// for example <code>my-db-param-group</code>, or a valid ARN.</li><li>If the source
        /// DB parameter group is in a different region than the copy, specify a valid DB parameter
        /// group ARN, for example <code>arn:aws:rds:us-west-2:123456789012:pg:special-parameters</code>.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String SourceDBParameterGroupIdentifier { get; set; }
        
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
        /// <para>A description for the copied DB parameter group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public String TargetDBParameterGroupDescription { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The identifier for the copied DB parameter group.</para><para>Constraints:</para><ul><li>Cannot be null, empty, or blank</li><li>Must contain from 1 to 255 alphanumeric
        /// characters or hyphens</li><li>First character must be a letter</li><li>Cannot end
        /// with a hyphen or contain two consecutive hyphens</li></ul><para>Example: <code>my-db-parameter-group</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public String TargetDBParameterGroupIdentifier { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SourceDBParameterGroupIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-RDSDBParameterGroup (CopyDBParameterGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.SourceDBParameterGroupIdentifier = this.SourceDBParameterGroupIdentifier;
            if (this.Tag != null)
            {
                context.Tags = new List<Tag>(this.Tag);
            }
            context.TargetDBParameterGroupDescription = this.TargetDBParameterGroupDescription;
            context.TargetDBParameterGroupIdentifier = this.TargetDBParameterGroupIdentifier;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CopyDBParameterGroupRequest();
            
            if (cmdletContext.SourceDBParameterGroupIdentifier != null)
            {
                request.SourceDBParameterGroupIdentifier = cmdletContext.SourceDBParameterGroupIdentifier;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.TargetDBParameterGroupDescription != null)
            {
                request.TargetDBParameterGroupDescription = cmdletContext.TargetDBParameterGroupDescription;
            }
            if (cmdletContext.TargetDBParameterGroupIdentifier != null)
            {
                request.TargetDBParameterGroupIdentifier = cmdletContext.TargetDBParameterGroupIdentifier;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CopyDBParameterGroup(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DBParameterGroup;
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
            public String SourceDBParameterGroupIdentifier { get; set; }
            public List<Tag> Tags { get; set; }
            public String TargetDBParameterGroupDescription { get; set; }
            public String TargetDBParameterGroupIdentifier { get; set; }
        }
        
    }
}

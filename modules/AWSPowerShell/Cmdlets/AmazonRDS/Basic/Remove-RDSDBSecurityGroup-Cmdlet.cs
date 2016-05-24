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
    /// Deletes a DB security group.
    /// 
    ///  <note><para>
    /// The specified DB security group must not be associated with any DB instances.
    /// </para></note>
    /// </summary>
    [Cmdlet("Remove", "RDSDBSecurityGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the DeleteDBSecurityGroup operation against Amazon Relational Database Service.", Operation = new[] {"DeleteDBSecurityGroup"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the DBSecurityGroupName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.RDS.Model.DeleteDBSecurityGroupResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RemoveRDSDBSecurityGroupCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter DBSecurityGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the DB security group to delete.</para><note><para>You cannot delete the default DB security group.</para></note><para>Constraints:</para><ul><li><para>Must be 1 to 255 alphanumeric characters</para></li><li><para>First character must be a letter</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens</para></li><li><para>Must not be "Default"</para></li><li><para>Cannot contain spaces</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DBSecurityGroupName { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the DBSecurityGroupName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DBSecurityGroupName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-RDSDBSecurityGroup (DeleteDBSecurityGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.DBSecurityGroupName = this.DBSecurityGroupName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.RDS.Model.DeleteDBSecurityGroupRequest();
            
            if (cmdletContext.DBSecurityGroupName != null)
            {
                request.DBSecurityGroupName = cmdletContext.DBSecurityGroupName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DeleteDBSecurityGroup(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.DBSecurityGroupName;
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
            public System.String DBSecurityGroupName { get; set; }
        }
        
    }
}

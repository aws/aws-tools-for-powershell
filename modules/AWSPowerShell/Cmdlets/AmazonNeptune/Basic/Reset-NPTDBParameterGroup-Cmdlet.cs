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
using Amazon.Neptune;
using Amazon.Neptune.Model;

namespace Amazon.PowerShell.Cmdlets.NPT
{
    /// <summary>
    /// Modifies the parameters of a DB parameter group to the engine/system default value.
    /// To reset specific parameters, provide a list of the following: <code>ParameterName</code>
    /// and <code>ApplyMethod</code>. To reset the entire DB parameter group, specify the
    /// <code>DBParameterGroup</code> name and <code>ResetAllParameters</code> parameters.
    /// When resetting the entire group, dynamic parameters are updated immediately and static
    /// parameters are set to <code>pending-reboot</code> to take effect on the next DB instance
    /// restart or <code>RebootDBInstance</code> request.
    /// </summary>
    [Cmdlet("Reset", "NPTDBParameterGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Neptune ResetDBParameterGroup API operation.", Operation = new[] {"ResetDBParameterGroup"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.Neptune.Model.ResetDBParameterGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ResetNPTDBParameterGroupCmdlet : AmazonNeptuneClientCmdlet, IExecutor
    {
        
        #region Parameter DBParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the DB parameter group.</para><para>Constraints:</para><ul><li><para>Must match the name of an existing DBParameterGroup.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DBParameterGroupName { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>To reset the entire DB parameter group, specify the <code>DBParameterGroup</code>
        /// name and <code>ResetAllParameters</code> parameters. To reset specific parameters,
        /// provide a list of the following: <code>ParameterName</code> and <code>ApplyMethod</code>.
        /// A maximum of 20 parameters can be modified in a single request.</para><para>Valid Values (for Apply method): <code>pending-reboot</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Parameters")]
        public Amazon.Neptune.Model.Parameter[] Parameter { get; set; }
        #endregion
        
        #region Parameter ResetAllParameter
        /// <summary>
        /// <para>
        /// <para> Specifies whether (<code>true</code>) or not (<code>false</code>) to reset all parameters
        /// in the DB parameter group to default values. </para><para>Default: <code>true</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResetAllParameters")]
        public System.Boolean ResetAllParameter { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DBParameterGroupName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Reset-NPTDBParameterGroup (ResetDBParameterGroup)"))
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
            
            context.DBParameterGroupName = this.DBParameterGroupName;
            if (this.Parameter != null)
            {
                context.Parameters = new List<Amazon.Neptune.Model.Parameter>(this.Parameter);
            }
            if (ParameterWasBound("ResetAllParameter"))
                context.ResetAllParameters = this.ResetAllParameter;
            
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
            var request = new Amazon.Neptune.Model.ResetDBParameterGroupRequest();
            
            if (cmdletContext.DBParameterGroupName != null)
            {
                request.DBParameterGroupName = cmdletContext.DBParameterGroupName;
            }
            if (cmdletContext.Parameters != null)
            {
                request.Parameters = cmdletContext.Parameters;
            }
            if (cmdletContext.ResetAllParameters != null)
            {
                request.ResetAllParameters = cmdletContext.ResetAllParameters.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DBParameterGroupName;
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
        
        private Amazon.Neptune.Model.ResetDBParameterGroupResponse CallAWSServiceOperation(IAmazonNeptune client, Amazon.Neptune.Model.ResetDBParameterGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Neptune", "ResetDBParameterGroup");
            try
            {
                #if DESKTOP
                return client.ResetDBParameterGroup(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ResetDBParameterGroupAsync(request);
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
            public System.String DBParameterGroupName { get; set; }
            public List<Amazon.Neptune.Model.Parameter> Parameters { get; set; }
            public System.Boolean? ResetAllParameters { get; set; }
        }
        
    }
}

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
using Amazon.DAX;
using Amazon.DAX.Model;

namespace Amazon.PowerShell.Cmdlets.DAX
{
    /// <summary>
    /// Modifies the parameters of a parameter group. You can modify up to 20 parameters in
    /// a single request by submitting a list parameter name and value pairs.
    /// </summary>
    [Cmdlet("Update", "DAXParameterGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DAX.Model.ParameterGroup")]
    [AWSCmdlet("Calls the Amazon DynamoDB Accelerator (DAX) UpdateParameterGroup API operation.", Operation = new[] {"UpdateParameterGroup"})]
    [AWSCmdletOutput("Amazon.DAX.Model.ParameterGroup",
        "This cmdlet returns a ParameterGroup object.",
        "The service call response (type Amazon.DAX.Model.UpdateParameterGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateDAXParameterGroupCmdlet : AmazonDAXClientCmdlet, IExecutor
    {
        
        #region Parameter ParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the parameter group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ParameterGroupName { get; set; }
        #endregion
        
        #region Parameter ParameterNameValue
        /// <summary>
        /// <para>
        /// <para>An array of name-value pairs for the parameters in the group. Each element in the
        /// array represents a single parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ParameterNameValues")]
        public Amazon.DAX.Model.ParameterNameValue[] ParameterNameValue { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ParameterGroupName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DAXParameterGroup (UpdateParameterGroup)"))
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
            
            context.ParameterGroupName = this.ParameterGroupName;
            if (this.ParameterNameValue != null)
            {
                context.ParameterNameValues = new List<Amazon.DAX.Model.ParameterNameValue>(this.ParameterNameValue);
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
            var request = new Amazon.DAX.Model.UpdateParameterGroupRequest();
            
            if (cmdletContext.ParameterGroupName != null)
            {
                request.ParameterGroupName = cmdletContext.ParameterGroupName;
            }
            if (cmdletContext.ParameterNameValues != null)
            {
                request.ParameterNameValues = cmdletContext.ParameterNameValues;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ParameterGroup;
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
        
        private Amazon.DAX.Model.UpdateParameterGroupResponse CallAWSServiceOperation(IAmazonDAX client, Amazon.DAX.Model.UpdateParameterGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB Accelerator (DAX)", "UpdateParameterGroup");
            try
            {
                #if DESKTOP
                return client.UpdateParameterGroup(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateParameterGroupAsync(request);
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
            public System.String ParameterGroupName { get; set; }
            public List<Amazon.DAX.Model.ParameterNameValue> ParameterNameValues { get; set; }
        }
        
    }
}

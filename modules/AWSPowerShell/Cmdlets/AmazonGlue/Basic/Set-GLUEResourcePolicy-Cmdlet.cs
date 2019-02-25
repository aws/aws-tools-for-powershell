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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Sets the Data Catalog resource policy for access control.
    /// </summary>
    [Cmdlet("Set", "GLUEResourcePolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Glue PutResourcePolicy API operation.", Operation = new[] {"PutResourcePolicy"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.Glue.Model.PutResourcePolicyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetGLUEResourcePolicyCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        #region Parameter PolicyExistsCondition
        /// <summary>
        /// <para>
        /// <para>A value of <code>MUST_EXIST</code> is used to update a policy. A value of <code>NOT_EXIST</code>
        /// is used to create a new policy. If a value of <code>NONE</code> or a null value is
        /// used, the call will not depend on the existence of a policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Glue.ExistCondition")]
        public Amazon.Glue.ExistCondition PolicyExistsCondition { get; set; }
        #endregion
        
        #region Parameter PolicyHashCondition
        /// <summary>
        /// <para>
        /// <para>The hash value returned when the previous policy was set using <code>PutResourcePolicy</code>.
        /// Its purpose is to prevent concurrent modifications of a policy. Do not use this parameter
        /// if no previous policy has been set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PolicyHashCondition { get; set; }
        #endregion
        
        #region Parameter PolicyInJson
        /// <summary>
        /// <para>
        /// <para>Contains the policy document to set, in JSON format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String PolicyInJson { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-GLUEResourcePolicy (PutResourcePolicy)"))
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
            
            context.PolicyExistsCondition = this.PolicyExistsCondition;
            context.PolicyHashCondition = this.PolicyHashCondition;
            context.PolicyInJson = this.PolicyInJson;
            
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
            var request = new Amazon.Glue.Model.PutResourcePolicyRequest();
            
            if (cmdletContext.PolicyExistsCondition != null)
            {
                request.PolicyExistsCondition = cmdletContext.PolicyExistsCondition;
            }
            if (cmdletContext.PolicyHashCondition != null)
            {
                request.PolicyHashCondition = cmdletContext.PolicyHashCondition;
            }
            if (cmdletContext.PolicyInJson != null)
            {
                request.PolicyInJson = cmdletContext.PolicyInJson;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.PolicyHash;
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
        
        private Amazon.Glue.Model.PutResourcePolicyResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.PutResourcePolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "PutResourcePolicy");
            try
            {
                #if DESKTOP
                return client.PutResourcePolicy(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutResourcePolicyAsync(request);
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
            public Amazon.Glue.ExistCondition PolicyExistsCondition { get; set; }
            public System.String PolicyHashCondition { get; set; }
            public System.String PolicyInJson { get; set; }
        }
        
    }
}

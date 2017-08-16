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
using Amazon.Greengrass;
using Amazon.Greengrass.Model;

namespace Amazon.PowerShell.Cmdlets.GG
{
    /// <summary>
    /// Create a version of a Lambda function definition that has already been defined.
    /// </summary>
    [Cmdlet("New", "GGFunctionDefinitionVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Greengrass.Model.CreateFunctionDefinitionVersionResponse")]
    [AWSCmdlet("Invokes the CreateFunctionDefinitionVersion operation against AWS Greengrass.", Operation = new[] {"CreateFunctionDefinitionVersion"})]
    [AWSCmdletOutput("Amazon.Greengrass.Model.CreateFunctionDefinitionVersionResponse",
        "This cmdlet returns a Amazon.Greengrass.Model.CreateFunctionDefinitionVersionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGGFunctionDefinitionVersionCmdlet : AmazonGreengrassClientCmdlet, IExecutor
    {
        
        #region Parameter AmznClientToken
        /// <summary>
        /// <para>
        /// The client token used to request idempotent
        /// operations.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AmznClientToken { get; set; }
        #endregion
        
        #region Parameter FunctionDefinitionId
        /// <summary>
        /// <para>
        /// the unique Id of the lambda definition
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String FunctionDefinitionId { get; set; }
        #endregion
        
        #region Parameter Function
        /// <summary>
        /// <para>
        /// Lambda functions in this function definition
        /// version.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Functions")]
        public Amazon.Greengrass.Model.Function[] Function { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("FunctionDefinitionId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GGFunctionDefinitionVersion (CreateFunctionDefinitionVersion)"))
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
            
            context.AmznClientToken = this.AmznClientToken;
            context.FunctionDefinitionId = this.FunctionDefinitionId;
            if (this.Function != null)
            {
                context.Functions = new List<Amazon.Greengrass.Model.Function>(this.Function);
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
            var request = new Amazon.Greengrass.Model.CreateFunctionDefinitionVersionRequest();
            
            if (cmdletContext.AmznClientToken != null)
            {
                request.AmznClientToken = cmdletContext.AmznClientToken;
            }
            if (cmdletContext.FunctionDefinitionId != null)
            {
                request.FunctionDefinitionId = cmdletContext.FunctionDefinitionId;
            }
            if (cmdletContext.Functions != null)
            {
                request.Functions = cmdletContext.Functions;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.Greengrass.Model.CreateFunctionDefinitionVersionResponse CallAWSServiceOperation(IAmazonGreengrass client, Amazon.Greengrass.Model.CreateFunctionDefinitionVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Greengrass", "CreateFunctionDefinitionVersion");
            try
            {
                #if DESKTOP
                return client.CreateFunctionDefinitionVersion(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateFunctionDefinitionVersionAsync(request);
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
            public System.String AmznClientToken { get; set; }
            public System.String FunctionDefinitionId { get; set; }
            public List<Amazon.Greengrass.Model.Function> Functions { get; set; }
        }
        
    }
}

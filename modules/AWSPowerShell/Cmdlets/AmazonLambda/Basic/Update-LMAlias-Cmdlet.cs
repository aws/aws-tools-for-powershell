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
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Using this API you can update the function version to which the alias points and the
    /// alias description. For more information, see <a href="http://docs.aws.amazon.com/lambda/latest/dg/aliases-intro.html">Introduction
    /// to AWS Lambda Aliases</a>.
    /// 
    ///  
    /// <para>
    /// This requires permission for the lambda:UpdateAlias action.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "LMAlias", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.UpdateAliasResponse")]
    [AWSCmdlet("Calls the AWS Lambda UpdateAlias API operation.", Operation = new[] {"UpdateAlias"})]
    [AWSCmdletOutput("Amazon.Lambda.Model.UpdateAliasResponse",
        "This cmdlet returns a Amazon.Lambda.Model.UpdateAliasResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateLMAliasCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        #region Parameter RoutingConfig_AdditionalVersionWeight
        /// <summary>
        /// <para>
        /// <para>Set this property value to dictate what percentage of traffic will invoke the updated
        /// function version. If set to an empty string, 100 percent of traffic will invoke <code>function-version</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RoutingConfig_AdditionalVersionWeights")]
        public System.Collections.Hashtable RoutingConfig_AdditionalVersionWeight { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>You can change the description of the alias using this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// <para>The function name for which the alias is created. Note that the length constraint
        /// applies only to the ARN. If you specify only the function name, it is limited to 64
        /// characters in length.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter FunctionVersion
        /// <summary>
        /// <para>
        /// <para>Using this parameter you can change the Lambda function version to which the alias
        /// points.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FunctionVersion { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The alias name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("FunctionName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LMAlias (UpdateAlias)"))
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
            
            context.Description = this.Description;
            context.FunctionName = this.FunctionName;
            context.FunctionVersion = this.FunctionVersion;
            context.Name = this.Name;
            if (this.RoutingConfig_AdditionalVersionWeight != null)
            {
                context.RoutingConfig_AdditionalVersionWeights = new Dictionary<System.String, System.Double>(StringComparer.Ordinal);
                foreach (var hashKey in this.RoutingConfig_AdditionalVersionWeight.Keys)
                {
                    context.RoutingConfig_AdditionalVersionWeights.Add((String)hashKey, (Double)(this.RoutingConfig_AdditionalVersionWeight[hashKey]));
                }
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
            var request = new Amazon.Lambda.Model.UpdateAliasRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FunctionName != null)
            {
                request.FunctionName = cmdletContext.FunctionName;
            }
            if (cmdletContext.FunctionVersion != null)
            {
                request.FunctionVersion = cmdletContext.FunctionVersion;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate RoutingConfig
            bool requestRoutingConfigIsNull = true;
            request.RoutingConfig = new Amazon.Lambda.Model.AliasRoutingConfiguration();
            Dictionary<System.String, System.Double> requestRoutingConfig_routingConfig_AdditionalVersionWeight = null;
            if (cmdletContext.RoutingConfig_AdditionalVersionWeights != null)
            {
                requestRoutingConfig_routingConfig_AdditionalVersionWeight = cmdletContext.RoutingConfig_AdditionalVersionWeights;
            }
            if (requestRoutingConfig_routingConfig_AdditionalVersionWeight != null)
            {
                request.RoutingConfig.AdditionalVersionWeights = requestRoutingConfig_routingConfig_AdditionalVersionWeight;
                requestRoutingConfigIsNull = false;
            }
             // determine if request.RoutingConfig should be set to null
            if (requestRoutingConfigIsNull)
            {
                request.RoutingConfig = null;
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
        
        private Amazon.Lambda.Model.UpdateAliasResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.UpdateAliasRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "UpdateAlias");
            try
            {
                #if DESKTOP
                return client.UpdateAlias(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateAliasAsync(request);
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
            public System.String Description { get; set; }
            public System.String FunctionName { get; set; }
            public System.String FunctionVersion { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.Double> RoutingConfig_AdditionalVersionWeights { get; set; }
        }
        
    }
}

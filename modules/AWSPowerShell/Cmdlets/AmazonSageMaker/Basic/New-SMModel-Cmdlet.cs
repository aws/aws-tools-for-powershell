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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Creates a model in Amazon SageMaker. In the request, you name the model and describe
    /// one or more containers. For each container, you specify the docker image containing
    /// inference code, artifacts (from prior training), and custom environment map that the
    /// inference code uses when you deploy the model into production. 
    /// 
    ///  
    /// <para>
    /// Use this API to create a model only if you want to use Amazon SageMaker hosting services.
    /// To host your model, you create an endpoint configuration with the <code>CreateEndpointConfig</code>
    /// API, and then create an endpoint with the <code>CreateEndpoint</code> API. 
    /// </para><para>
    /// Amazon SageMaker then deploys all of the containers that you defined for the model
    /// in the hosting environment. 
    /// </para><para>
    /// In the <code>CreateModel</code> request, you must define a container with the <code>PrimaryContainer</code>
    /// parameter. 
    /// </para><para>
    /// In the request, you also provide an IAM role that Amazon SageMaker can assume to access
    /// model artifacts and docker image for deployment on ML compute hosting instances. In
    /// addition, you also use the IAM role to manage permissions the inference code needs.
    /// For example, if the inference code access any other AWS resources, you grant necessary
    /// permissions via this role.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateModel API operation.", Operation = new[] {"CreateModel"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateModelResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMModelCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that Amazon SageMaker can assume to
        /// access model artifacts and docker image for deployment on ML compute instances. Deploying
        /// on ML compute instances is part of model hosting. For more information, see <a href="http://docs.aws.amazon.com/sagemaker/latest/dg/sagemaker-roles.html">Amazon
        /// SageMaker Roles</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter ModelName
        /// <summary>
        /// <para>
        /// <para>The name of the new model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ModelName { get; set; }
        #endregion
        
        #region Parameter PrimaryContainer
        /// <summary>
        /// <para>
        /// <para>The location of the primary docker image containing inference code, associated artifacts,
        /// and custom environment map that the inference code uses when the model is deployed
        /// into production. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public Amazon.SageMaker.Model.ContainerDefinition PrimaryContainer { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs. For more information, see <a href="http://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/cost-alloc-tags.html#allocation-what">Using
        /// Cost Allocation Tags</a> in the <i>AWS Billing and Cost Management User Guide</i>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ModelName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMModel (CreateModel)"))
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
            
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            context.ModelName = this.ModelName;
            context.PrimaryContainer = this.PrimaryContainer;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
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
            var request = new Amazon.SageMaker.Model.CreateModelRequest();
            
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            if (cmdletContext.ModelName != null)
            {
                request.ModelName = cmdletContext.ModelName;
            }
            if (cmdletContext.PrimaryContainer != null)
            {
                request.PrimaryContainer = cmdletContext.PrimaryContainer;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ModelArn;
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
        
        private Amazon.SageMaker.Model.CreateModelResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateModel");
            try
            {
                #if DESKTOP
                return client.CreateModel(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateModelAsync(request);
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
            public System.String ExecutionRoleArn { get; set; }
            public System.String ModelName { get; set; }
            public Amazon.SageMaker.Model.ContainerDefinition PrimaryContainer { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tags { get; set; }
        }
        
    }
}

/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Neptunedata;
using Amazon.Neptunedata.Model;

namespace Amazon.PowerShell.Cmdlets.NEPT
{
    /// <summary>
    /// Returns a list of model transform job IDs. See <a href="https://docs.aws.amazon.com/neptune/latest/userguide/machine-learning-model-transform.html">Use
    /// a trained model to generate new model artifacts</a>.
    /// 
    ///  
    /// <para>
    /// When invoking this operation in a Neptune cluster that has IAM authentication enabled,
    /// the IAM user or role making the request must have a policy attached that allows the
    /// <a href="https://docs.aws.amazon.com/neptune/latest/userguide/iam-dp-actions.html#listmlmodeltransformjobs">neptune-db:ListMLModelTransformJobs</a>
    /// IAM action in that cluster.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "NEPTMLModelTransformJobList")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon NeptuneData ListMLModelTransformJobs API operation.", Operation = new[] {"ListMLModelTransformJobs"}, SelectReturnType = typeof(Amazon.Neptunedata.Model.ListMLModelTransformJobsResponse))]
    [AWSCmdletOutput("System.String or Amazon.Neptunedata.Model.ListMLModelTransformJobsResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.Neptunedata.Model.ListMLModelTransformJobsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetNEPTMLModelTransformJobListCmdlet : AmazonNeptunedataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter NeptuneIamRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM role that provides Neptune access to SageMaker and Amazon S3 resources.
        /// This must be listed in your DB cluster parameter group or an error will occur.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String NeptuneIamRoleArn { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return (from 1 to 1024; the default is 10).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public System.Int32? MaxItem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Ids'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Neptunedata.Model.ListMLModelTransformJobsResponse).
        /// Specifying the name of a property of type Amazon.Neptunedata.Model.ListMLModelTransformJobsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Ids";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the NeptuneIamRoleArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^NeptuneIamRoleArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^NeptuneIamRoleArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Neptunedata.Model.ListMLModelTransformJobsResponse, GetNEPTMLModelTransformJobListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.NeptuneIamRoleArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxItem = this.MaxItem;
            context.NeptuneIamRoleArn = this.NeptuneIamRoleArn;
            
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
            var request = new Amazon.Neptunedata.Model.ListMLModelTransformJobsRequest();
            
            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = cmdletContext.MaxItem.Value;
            }
            if (cmdletContext.NeptuneIamRoleArn != null)
            {
                request.NeptuneIamRoleArn = cmdletContext.NeptuneIamRoleArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.Neptunedata.Model.ListMLModelTransformJobsResponse CallAWSServiceOperation(IAmazonNeptunedata client, Amazon.Neptunedata.Model.ListMLModelTransformJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon NeptuneData", "ListMLModelTransformJobs");
            try
            {
                #if DESKTOP
                return client.ListMLModelTransformJobs(request);
                #elif CORECLR
                return client.ListMLModelTransformJobsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxItem { get; set; }
            public System.String NeptuneIamRoleArn { get; set; }
            public System.Func<Amazon.Neptunedata.Model.ListMLModelTransformJobsResponse, GetNEPTMLModelTransformJobListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Ids;
        }
        
    }
}

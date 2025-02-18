/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.RoboMaker;
using Amazon.RoboMaker.Model;

namespace Amazon.PowerShell.Cmdlets.ROBO
{
    /// <summary>
    /// <important><para>
    /// End of support notice: On September 10, 2025, Amazon Web Services will discontinue
    /// support for Amazon Web Services RoboMaker. After September 10, 2025, you will no longer
    /// be able to access the Amazon Web Services RoboMaker console or Amazon Web Services
    /// RoboMaker resources. For more information on transitioning to Batch to help run containerized
    /// simulations, visit <a href="https://aws.amazon.com/blogs/hpc/run-simulations-using-multiple-containers-in-a-single-aws-batch-job/">https://aws.amazon.com/blogs/hpc/run-simulations-using-multiple-containers-in-a-single-aws-batch-job/</a>.
    /// 
    /// </para></important><para>
    /// Updates a world template.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "ROBOWorldTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RoboMaker.Model.UpdateWorldTemplateResponse")]
    [AWSCmdlet("Calls the AWS RoboMaker UpdateWorldTemplate API operation.", Operation = new[] {"UpdateWorldTemplate"}, SelectReturnType = typeof(Amazon.RoboMaker.Model.UpdateWorldTemplateResponse))]
    [AWSCmdletOutput("Amazon.RoboMaker.Model.UpdateWorldTemplateResponse",
        "This cmdlet returns an Amazon.RoboMaker.Model.UpdateWorldTemplateResponse object containing multiple properties."
    )]
    public partial class UpdateROBOWorldTemplateCmdlet : AmazonRoboMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter TemplateLocation_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateLocation_S3Bucket { get; set; }
        #endregion
        
        #region Parameter TemplateLocation_S3Key
        /// <summary>
        /// <para>
        /// <para>The list of S3 keys identifying the data source files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateLocation_S3Key { get; set; }
        #endregion
        
        #region Parameter Template
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (arn) of the world template to update.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Template { get; set; }
        #endregion
        
        #region Parameter TemplateBody
        /// <summary>
        /// <para>
        /// <para>The world template body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateBody { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RoboMaker.Model.UpdateWorldTemplateResponse).
        /// Specifying the name of a property of type Amazon.RoboMaker.Model.UpdateWorldTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ROBOWorldTemplate (UpdateWorldTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RoboMaker.Model.UpdateWorldTemplateResponse, UpdateROBOWorldTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Name = this.Name;
            context.Template = this.Template;
            #if MODULAR
            if (this.Template == null && ParameterWasBound(nameof(this.Template)))
            {
                WriteWarning("You are passing $null as a value for parameter Template which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TemplateBody = this.TemplateBody;
            context.TemplateLocation_S3Bucket = this.TemplateLocation_S3Bucket;
            context.TemplateLocation_S3Key = this.TemplateLocation_S3Key;
            
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
            var request = new Amazon.RoboMaker.Model.UpdateWorldTemplateRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Template != null)
            {
                request.Template = cmdletContext.Template;
            }
            if (cmdletContext.TemplateBody != null)
            {
                request.TemplateBody = cmdletContext.TemplateBody;
            }
            
             // populate TemplateLocation
            var requestTemplateLocationIsNull = true;
            request.TemplateLocation = new Amazon.RoboMaker.Model.TemplateLocation();
            System.String requestTemplateLocation_templateLocation_S3Bucket = null;
            if (cmdletContext.TemplateLocation_S3Bucket != null)
            {
                requestTemplateLocation_templateLocation_S3Bucket = cmdletContext.TemplateLocation_S3Bucket;
            }
            if (requestTemplateLocation_templateLocation_S3Bucket != null)
            {
                request.TemplateLocation.S3Bucket = requestTemplateLocation_templateLocation_S3Bucket;
                requestTemplateLocationIsNull = false;
            }
            System.String requestTemplateLocation_templateLocation_S3Key = null;
            if (cmdletContext.TemplateLocation_S3Key != null)
            {
                requestTemplateLocation_templateLocation_S3Key = cmdletContext.TemplateLocation_S3Key;
            }
            if (requestTemplateLocation_templateLocation_S3Key != null)
            {
                request.TemplateLocation.S3Key = requestTemplateLocation_templateLocation_S3Key;
                requestTemplateLocationIsNull = false;
            }
             // determine if request.TemplateLocation should be set to null
            if (requestTemplateLocationIsNull)
            {
                request.TemplateLocation = null;
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
        
        private Amazon.RoboMaker.Model.UpdateWorldTemplateResponse CallAWSServiceOperation(IAmazonRoboMaker client, Amazon.RoboMaker.Model.UpdateWorldTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS RoboMaker", "UpdateWorldTemplate");
            try
            {
                return client.UpdateWorldTemplateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public System.String Template { get; set; }
            public System.String TemplateBody { get; set; }
            public System.String TemplateLocation_S3Bucket { get; set; }
            public System.String TemplateLocation_S3Key { get; set; }
            public System.Func<Amazon.RoboMaker.Model.UpdateWorldTemplateResponse, UpdateROBOWorldTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

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
using Amazon.Translate;
using Amazon.Translate.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.TRN
{
    /// <summary>
    /// Updates a previously created parallel data resource by importing a new input file
    /// from Amazon S3.
    /// </summary>
    [Cmdlet("Update", "TRNParallelData", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Translate.Model.UpdateParallelDataResponse")]
    [AWSCmdlet("Calls the Amazon Translate UpdateParallelData API operation.", Operation = new[] {"UpdateParallelData"}, SelectReturnType = typeof(Amazon.Translate.Model.UpdateParallelDataResponse))]
    [AWSCmdletOutput("Amazon.Translate.Model.UpdateParallelDataResponse",
        "This cmdlet returns an Amazon.Translate.Model.UpdateParallelDataResponse object containing multiple properties."
    )]
    public partial class UpdateTRNParallelDataCmdlet : AmazonTranslateClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A custom description for the parallel data resource in Amazon Translate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ParallelDataConfig_Format
        /// <summary>
        /// <para>
        /// <para>The format of the parallel data input file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Translate.ParallelDataFormat")]
        public Amazon.Translate.ParallelDataFormat ParallelDataConfig_Format { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the parallel data resource being updated.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ParallelDataConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>The URI of the Amazon S3 folder that contains the parallel data input file. The folder
        /// must be in the same Region as the API endpoint you are calling.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParallelDataConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the request. This token is automatically generated when you
        /// use Amazon Translate through an AWS SDK.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Translate.Model.UpdateParallelDataResponse).
        /// Specifying the name of a property of type Amazon.Translate.Model.UpdateParallelDataResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-TRNParallelData (UpdateParallelData)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Translate.Model.UpdateParallelDataResponse, UpdateTRNParallelDataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ParallelDataConfig_Format = this.ParallelDataConfig_Format;
            context.ParallelDataConfig_S3Uri = this.ParallelDataConfig_S3Uri;
            
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
            var request = new Amazon.Translate.Model.UpdateParallelDataRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate ParallelDataConfig
            var requestParallelDataConfigIsNull = true;
            request.ParallelDataConfig = new Amazon.Translate.Model.ParallelDataConfig();
            Amazon.Translate.ParallelDataFormat requestParallelDataConfig_parallelDataConfig_Format = null;
            if (cmdletContext.ParallelDataConfig_Format != null)
            {
                requestParallelDataConfig_parallelDataConfig_Format = cmdletContext.ParallelDataConfig_Format;
            }
            if (requestParallelDataConfig_parallelDataConfig_Format != null)
            {
                request.ParallelDataConfig.Format = requestParallelDataConfig_parallelDataConfig_Format;
                requestParallelDataConfigIsNull = false;
            }
            System.String requestParallelDataConfig_parallelDataConfig_S3Uri = null;
            if (cmdletContext.ParallelDataConfig_S3Uri != null)
            {
                requestParallelDataConfig_parallelDataConfig_S3Uri = cmdletContext.ParallelDataConfig_S3Uri;
            }
            if (requestParallelDataConfig_parallelDataConfig_S3Uri != null)
            {
                request.ParallelDataConfig.S3Uri = requestParallelDataConfig_parallelDataConfig_S3Uri;
                requestParallelDataConfigIsNull = false;
            }
             // determine if request.ParallelDataConfig should be set to null
            if (requestParallelDataConfigIsNull)
            {
                request.ParallelDataConfig = null;
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
        
        private Amazon.Translate.Model.UpdateParallelDataResponse CallAWSServiceOperation(IAmazonTranslate client, Amazon.Translate.Model.UpdateParallelDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Translate", "UpdateParallelData");
            try
            {
                return client.UpdateParallelDataAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public Amazon.Translate.ParallelDataFormat ParallelDataConfig_Format { get; set; }
            public System.String ParallelDataConfig_S3Uri { get; set; }
            public System.Func<Amazon.Translate.Model.UpdateParallelDataResponse, UpdateTRNParallelDataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

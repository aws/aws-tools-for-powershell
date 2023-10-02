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
using Amazon.Mgn;
using Amazon.Mgn.Model;

namespace Amazon.PowerShell.Cmdlets.MGN
{
    /// <summary>
    /// Start import.
    /// </summary>
    [Cmdlet("Start", "MGNImport", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Mgn.Model.ImportTask")]
    [AWSCmdlet("Calls the Application Migration Service StartImport API operation.", Operation = new[] {"StartImport"}, SelectReturnType = typeof(Amazon.Mgn.Model.StartImportResponse))]
    [AWSCmdletOutput("Amazon.Mgn.Model.ImportTask or Amazon.Mgn.Model.StartImportResponse",
        "This cmdlet returns an Amazon.Mgn.Model.ImportTask object.",
        "The service call response (type Amazon.Mgn.Model.StartImportResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartMGNImportCmdlet : AmazonMgnClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3BucketSource_S3Bucket
        /// <summary>
        /// <para>
        /// <para>S3 bucket source s3 bucket.</para>
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
        public System.String S3BucketSource_S3Bucket { get; set; }
        #endregion
        
        #region Parameter S3BucketSource_S3BucketOwner
        /// <summary>
        /// <para>
        /// <para>S3 bucket source s3 bucket owner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3BucketSource_S3BucketOwner { get; set; }
        #endregion
        
        #region Parameter S3BucketSource_S3Key
        /// <summary>
        /// <para>
        /// <para>S3 bucket source s3 key.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String S3BucketSource_S3Key { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Start import request client token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ImportTask'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Mgn.Model.StartImportResponse).
        /// Specifying the name of a property of type Amazon.Mgn.Model.StartImportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ImportTask";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the S3BucketSource_S3Bucket parameter.
        /// The -PassThru parameter is deprecated, use -Select '^S3BucketSource_S3Bucket' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^S3BucketSource_S3Bucket' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.S3BucketSource_S3Bucket), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-MGNImport (StartImport)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Mgn.Model.StartImportResponse, StartMGNImportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.S3BucketSource_S3Bucket;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.S3BucketSource_S3Bucket = this.S3BucketSource_S3Bucket;
            #if MODULAR
            if (this.S3BucketSource_S3Bucket == null && ParameterWasBound(nameof(this.S3BucketSource_S3Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter S3BucketSource_S3Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3BucketSource_S3BucketOwner = this.S3BucketSource_S3BucketOwner;
            context.S3BucketSource_S3Key = this.S3BucketSource_S3Key;
            #if MODULAR
            if (this.S3BucketSource_S3Key == null && ParameterWasBound(nameof(this.S3BucketSource_S3Key)))
            {
                WriteWarning("You are passing $null as a value for parameter S3BucketSource_S3Key which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.Mgn.Model.StartImportRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate S3BucketSource
            var requestS3BucketSourceIsNull = true;
            request.S3BucketSource = new Amazon.Mgn.Model.S3BucketSource();
            System.String requestS3BucketSource_s3BucketSource_S3Bucket = null;
            if (cmdletContext.S3BucketSource_S3Bucket != null)
            {
                requestS3BucketSource_s3BucketSource_S3Bucket = cmdletContext.S3BucketSource_S3Bucket;
            }
            if (requestS3BucketSource_s3BucketSource_S3Bucket != null)
            {
                request.S3BucketSource.S3Bucket = requestS3BucketSource_s3BucketSource_S3Bucket;
                requestS3BucketSourceIsNull = false;
            }
            System.String requestS3BucketSource_s3BucketSource_S3BucketOwner = null;
            if (cmdletContext.S3BucketSource_S3BucketOwner != null)
            {
                requestS3BucketSource_s3BucketSource_S3BucketOwner = cmdletContext.S3BucketSource_S3BucketOwner;
            }
            if (requestS3BucketSource_s3BucketSource_S3BucketOwner != null)
            {
                request.S3BucketSource.S3BucketOwner = requestS3BucketSource_s3BucketSource_S3BucketOwner;
                requestS3BucketSourceIsNull = false;
            }
            System.String requestS3BucketSource_s3BucketSource_S3Key = null;
            if (cmdletContext.S3BucketSource_S3Key != null)
            {
                requestS3BucketSource_s3BucketSource_S3Key = cmdletContext.S3BucketSource_S3Key;
            }
            if (requestS3BucketSource_s3BucketSource_S3Key != null)
            {
                request.S3BucketSource.S3Key = requestS3BucketSource_s3BucketSource_S3Key;
                requestS3BucketSourceIsNull = false;
            }
             // determine if request.S3BucketSource should be set to null
            if (requestS3BucketSourceIsNull)
            {
                request.S3BucketSource = null;
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
        
        private Amazon.Mgn.Model.StartImportResponse CallAWSServiceOperation(IAmazonMgn client, Amazon.Mgn.Model.StartImportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Migration Service", "StartImport");
            try
            {
                #if DESKTOP
                return client.StartImport(request);
                #elif CORECLR
                return client.StartImportAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String S3BucketSource_S3Bucket { get; set; }
            public System.String S3BucketSource_S3BucketOwner { get; set; }
            public System.String S3BucketSource_S3Key { get; set; }
            public System.Func<Amazon.Mgn.Model.StartImportResponse, StartMGNImportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ImportTask;
        }
        
    }
}

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
using Amazon.Snowball;
using Amazon.Snowball.Model;

namespace Amazon.PowerShell.Cmdlets.SNOW
{
    /// <summary>
    /// Returns a link to an Amazon S3 presigned URL for the manifest file associated with
    /// the specified <c>JobId</c> value. You can access the manifest file for up to 60 minutes
    /// after this request has been made. To access the manifest file after 60 minutes have
    /// passed, you'll have to make another call to the <c>GetJobManifest</c> action.
    /// 
    ///  
    /// <para>
    /// The manifest is an encrypted file that you can download after your job enters the
    /// <c>WithCustomer</c> status. This is the only valid status for calling this API as
    /// the manifest and <c>UnlockCode</c> code value are used for securing your device and
    /// should only be used when you have the device. The manifest is decrypted by using the
    /// <c>UnlockCode</c> code value, when you pass both values to the Snow device through
    /// the Snowball client when the client is started for the first time. 
    /// </para><para>
    /// As a best practice, we recommend that you don't save a copy of an <c>UnlockCode</c>
    /// value in the same location as the manifest file for that job. Saving these separately
    /// helps prevent unauthorized parties from gaining access to the Snow device associated
    /// with that job.
    /// </para><para>
    /// The credentials of a given job, including its manifest file and unlock code, expire
    /// 360 days after the job is created.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SNOWJobManifest")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Import/Export Snowball GetJobManifest API operation.", Operation = new[] {"GetJobManifest"}, SelectReturnType = typeof(Amazon.Snowball.Model.GetJobManifestResponse))]
    [AWSCmdletOutput("System.String or Amazon.Snowball.Model.GetJobManifestResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Snowball.Model.GetJobManifestResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSNOWJobManifestCmdlet : AmazonSnowballClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para>The ID for a job that you want to get the manifest file for, for example <c>JID123e4567-e89b-12d3-a456-426655440000</c>.</para>
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
        public System.String JobId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ManifestURI'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Snowball.Model.GetJobManifestResponse).
        /// Specifying the name of a property of type Amazon.Snowball.Model.GetJobManifestResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ManifestURI";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Snowball.Model.GetJobManifestResponse, GetSNOWJobManifestCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.JobId = this.JobId;
            #if MODULAR
            if (this.JobId == null && ParameterWasBound(nameof(this.JobId)))
            {
                WriteWarning("You are passing $null as a value for parameter JobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Snowball.Model.GetJobManifestRequest();
            
            if (cmdletContext.JobId != null)
            {
                request.JobId = cmdletContext.JobId;
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
        
        private Amazon.Snowball.Model.GetJobManifestResponse CallAWSServiceOperation(IAmazonSnowball client, Amazon.Snowball.Model.GetJobManifestRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Import/Export Snowball", "GetJobManifest");
            try
            {
                #if DESKTOP
                return client.GetJobManifest(request);
                #elif CORECLR
                return client.GetJobManifestAsync(request).GetAwaiter().GetResult();
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
            public System.String JobId { get; set; }
            public System.Func<Amazon.Snowball.Model.GetJobManifestResponse, GetSNOWJobManifestCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ManifestURI;
        }
        
    }
}

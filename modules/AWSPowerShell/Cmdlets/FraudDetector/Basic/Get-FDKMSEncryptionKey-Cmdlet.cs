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
using Amazon.FraudDetector;
using Amazon.FraudDetector.Model;

namespace Amazon.PowerShell.Cmdlets.FD
{
    /// <summary>
    /// Gets the encryption key if a Key Management Service (KMS) customer master key (CMK)
    /// has been specified to be used to encrypt content in Amazon Fraud Detector.
    /// </summary>
    [Cmdlet("Get", "FDKMSEncryptionKey")]
    [OutputType("Amazon.FraudDetector.Model.KMSKey")]
    [AWSCmdlet("Calls the Amazon Fraud Detector GetKMSEncryptionKey API operation.", Operation = new[] {"GetKMSEncryptionKey"}, SelectReturnType = typeof(Amazon.FraudDetector.Model.GetKMSEncryptionKeyResponse))]
    [AWSCmdletOutput("Amazon.FraudDetector.Model.KMSKey or Amazon.FraudDetector.Model.GetKMSEncryptionKeyResponse",
        "This cmdlet returns an Amazon.FraudDetector.Model.KMSKey object.",
        "The service call response (type Amazon.FraudDetector.Model.GetKMSEncryptionKeyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetFDKMSEncryptionKeyCmdlet : AmazonFraudDetectorClientCmdlet, IExecutor
    {
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'KmsKey'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FraudDetector.Model.GetKMSEncryptionKeyResponse).
        /// Specifying the name of a property of type Amazon.FraudDetector.Model.GetKMSEncryptionKeyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "KmsKey";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FraudDetector.Model.GetKMSEncryptionKeyResponse, GetFDKMSEncryptionKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
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
            var request = new Amazon.FraudDetector.Model.GetKMSEncryptionKeyRequest();
            
            
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
        
        private Amazon.FraudDetector.Model.GetKMSEncryptionKeyResponse CallAWSServiceOperation(IAmazonFraudDetector client, Amazon.FraudDetector.Model.GetKMSEncryptionKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Fraud Detector", "GetKMSEncryptionKey");
            try
            {
                #if DESKTOP
                return client.GetKMSEncryptionKey(request);
                #elif CORECLR
                return client.GetKMSEncryptionKeyAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.FraudDetector.Model.GetKMSEncryptionKeyResponse, GetFDKMSEncryptionKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.KmsKey;
        }
        
    }
}

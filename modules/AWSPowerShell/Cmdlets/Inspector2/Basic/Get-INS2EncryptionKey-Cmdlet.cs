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
using Amazon.Inspector2;
using Amazon.Inspector2.Model;

namespace Amazon.PowerShell.Cmdlets.INS2
{
    /// <summary>
    /// Gets an encryption key.
    /// </summary>
    [Cmdlet("Get", "INS2EncryptionKey")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Inspector2 GetEncryptionKey API operation.", Operation = new[] {"GetEncryptionKey"}, SelectReturnType = typeof(Amazon.Inspector2.Model.GetEncryptionKeyResponse))]
    [AWSCmdletOutput("System.String or Amazon.Inspector2.Model.GetEncryptionKeyResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Inspector2.Model.GetEncryptionKeyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetINS2EncryptionKeyCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The resource type the key encrypts.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Inspector2.ResourceType")]
        public Amazon.Inspector2.ResourceType ResourceType { get; set; }
        #endregion
        
        #region Parameter ScanType
        /// <summary>
        /// <para>
        /// <para>The scan type the key encrypts.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Inspector2.ScanType")]
        public Amazon.Inspector2.ScanType ScanType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'KmsKeyId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.GetEncryptionKeyResponse).
        /// Specifying the name of a property of type Amazon.Inspector2.Model.GetEncryptionKeyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "KmsKeyId";
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
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.GetEncryptionKeyResponse, GetINS2EncryptionKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ResourceType = this.ResourceType;
            #if MODULAR
            if (this.ResourceType == null && ParameterWasBound(nameof(this.ResourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScanType = this.ScanType;
            #if MODULAR
            if (this.ScanType == null && ParameterWasBound(nameof(this.ScanType)))
            {
                WriteWarning("You are passing $null as a value for parameter ScanType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Inspector2.Model.GetEncryptionKeyRequest();
            
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
            }
            if (cmdletContext.ScanType != null)
            {
                request.ScanType = cmdletContext.ScanType;
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
        
        private Amazon.Inspector2.Model.GetEncryptionKeyResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.GetEncryptionKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "GetEncryptionKey");
            try
            {
                #if DESKTOP
                return client.GetEncryptionKey(request);
                #elif CORECLR
                return client.GetEncryptionKeyAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Inspector2.ResourceType ResourceType { get; set; }
            public Amazon.Inspector2.ScanType ScanType { get; set; }
            public System.Func<Amazon.Inspector2.Model.GetEncryptionKeyResponse, GetINS2EncryptionKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.KmsKeyId;
        }
        
    }
}

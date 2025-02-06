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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Returns a description of the specified model package, which is used to create SageMaker
    /// models or list them on Amazon Web Services Marketplace.
    /// 
    ///  <important><para>
    /// If you provided a KMS Key ID when you created your model package, you will see the
    /// <a href="https://docs.aws.amazon.com/kms/latest/APIReference/API_Decrypt.html">KMS
    /// Decrypt</a> API call in your CloudTrail logs when you use this API.
    /// </para></important><para>
    /// To create models in SageMaker, buyers can subscribe to model packages listed on Amazon
    /// Web Services Marketplace.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SMModelPackage")]
    [OutputType("Amazon.SageMaker.Model.DescribeModelPackageResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Service DescribeModelPackage API operation.", Operation = new[] {"DescribeModelPackage"}, SelectReturnType = typeof(Amazon.SageMaker.Model.DescribeModelPackageResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.DescribeModelPackageResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.DescribeModelPackageResponse object containing multiple properties."
    )]
    public partial class GetSMModelPackageCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ModelPackageName
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the model package to describe.</para><para>When you specify a name, the name must have 1 to 63 characters. Valid characters are
        /// a-z, A-Z, 0-9, and - (hyphen).</para>
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
        public System.String ModelPackageName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.DescribeModelPackageResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.DescribeModelPackageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.DescribeModelPackageResponse, GetSMModelPackageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ModelPackageName = this.ModelPackageName;
            #if MODULAR
            if (this.ModelPackageName == null && ParameterWasBound(nameof(this.ModelPackageName)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelPackageName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMaker.Model.DescribeModelPackageRequest();
            
            if (cmdletContext.ModelPackageName != null)
            {
                request.ModelPackageName = cmdletContext.ModelPackageName;
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
        
        private Amazon.SageMaker.Model.DescribeModelPackageResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.DescribeModelPackageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "DescribeModelPackage");
            try
            {
                #if DESKTOP
                return client.DescribeModelPackage(request);
                #elif CORECLR
                return client.DescribeModelPackageAsync(request).GetAwaiter().GetResult();
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
            public System.String ModelPackageName { get; set; }
            public System.Func<Amazon.SageMaker.Model.DescribeModelPackageResponse, GetSMModelPackageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

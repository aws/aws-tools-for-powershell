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
using Amazon.Elasticsearch;
using Amazon.Elasticsearch.Model;

namespace Amazon.PowerShell.Cmdlets.ES
{
    /// <summary>
    /// Create a package for use with Amazon ES domains.
    /// </summary>
    [Cmdlet("New", "ESPackage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Elasticsearch.Model.PackageDetails")]
    [AWSCmdlet("Calls the Amazon Elasticsearch CreatePackage API operation.", Operation = new[] {"CreatePackage"}, SelectReturnType = typeof(Amazon.Elasticsearch.Model.CreatePackageResponse))]
    [AWSCmdletOutput("Amazon.Elasticsearch.Model.PackageDetails or Amazon.Elasticsearch.Model.CreatePackageResponse",
        "This cmdlet returns an Amazon.Elasticsearch.Model.PackageDetails object.",
        "The service call response (type Amazon.Elasticsearch.Model.CreatePackageResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewESPackageCmdlet : AmazonElasticsearchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PackageDescription
        /// <summary>
        /// <para>
        /// <para>Description of the package.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PackageDescription { get; set; }
        #endregion
        
        #region Parameter PackageName
        /// <summary>
        /// <para>
        /// <para>Unique identifier for the package.</para>
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
        public System.String PackageName { get; set; }
        #endregion
        
        #region Parameter PackageType
        /// <summary>
        /// <para>
        /// <para>Type of package. Currently supports only TXT-DICTIONARY.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Elasticsearch.PackageType")]
        public Amazon.Elasticsearch.PackageType PackageType { get; set; }
        #endregion
        
        #region Parameter PackageSource_S3BucketName
        /// <summary>
        /// <para>
        /// <para>Name of the bucket containing the package.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PackageSource_S3BucketName { get; set; }
        #endregion
        
        #region Parameter PackageSource_S3Key
        /// <summary>
        /// <para>
        /// <para>Key (file name) of the package.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PackageSource_S3Key { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PackageDetails'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Elasticsearch.Model.CreatePackageResponse).
        /// Specifying the name of a property of type Amazon.Elasticsearch.Model.CreatePackageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PackageDetails";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PackageName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ESPackage (CreatePackage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Elasticsearch.Model.CreatePackageResponse, NewESPackageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.PackageDescription = this.PackageDescription;
            context.PackageName = this.PackageName;
            #if MODULAR
            if (this.PackageName == null && ParameterWasBound(nameof(this.PackageName)))
            {
                WriteWarning("You are passing $null as a value for parameter PackageName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PackageSource_S3BucketName = this.PackageSource_S3BucketName;
            context.PackageSource_S3Key = this.PackageSource_S3Key;
            context.PackageType = this.PackageType;
            #if MODULAR
            if (this.PackageType == null && ParameterWasBound(nameof(this.PackageType)))
            {
                WriteWarning("You are passing $null as a value for parameter PackageType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Elasticsearch.Model.CreatePackageRequest();
            
            if (cmdletContext.PackageDescription != null)
            {
                request.PackageDescription = cmdletContext.PackageDescription;
            }
            if (cmdletContext.PackageName != null)
            {
                request.PackageName = cmdletContext.PackageName;
            }
            
             // populate PackageSource
            var requestPackageSourceIsNull = true;
            request.PackageSource = new Amazon.Elasticsearch.Model.PackageSource();
            System.String requestPackageSource_packageSource_S3BucketName = null;
            if (cmdletContext.PackageSource_S3BucketName != null)
            {
                requestPackageSource_packageSource_S3BucketName = cmdletContext.PackageSource_S3BucketName;
            }
            if (requestPackageSource_packageSource_S3BucketName != null)
            {
                request.PackageSource.S3BucketName = requestPackageSource_packageSource_S3BucketName;
                requestPackageSourceIsNull = false;
            }
            System.String requestPackageSource_packageSource_S3Key = null;
            if (cmdletContext.PackageSource_S3Key != null)
            {
                requestPackageSource_packageSource_S3Key = cmdletContext.PackageSource_S3Key;
            }
            if (requestPackageSource_packageSource_S3Key != null)
            {
                request.PackageSource.S3Key = requestPackageSource_packageSource_S3Key;
                requestPackageSourceIsNull = false;
            }
             // determine if request.PackageSource should be set to null
            if (requestPackageSourceIsNull)
            {
                request.PackageSource = null;
            }
            if (cmdletContext.PackageType != null)
            {
                request.PackageType = cmdletContext.PackageType;
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
        
        private Amazon.Elasticsearch.Model.CreatePackageResponse CallAWSServiceOperation(IAmazonElasticsearch client, Amazon.Elasticsearch.Model.CreatePackageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elasticsearch", "CreatePackage");
            try
            {
                #if DESKTOP
                return client.CreatePackage(request);
                #elif CORECLR
                return client.CreatePackageAsync(request).GetAwaiter().GetResult();
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
            public System.String PackageDescription { get; set; }
            public System.String PackageName { get; set; }
            public System.String PackageSource_S3BucketName { get; set; }
            public System.String PackageSource_S3Key { get; set; }
            public Amazon.Elasticsearch.PackageType PackageType { get; set; }
            public System.Func<Amazon.Elasticsearch.Model.CreatePackageResponse, NewESPackageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PackageDetails;
        }
        
    }
}

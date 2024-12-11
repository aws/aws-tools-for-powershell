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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Associates the selected software bill of materials (SBOM) with a specific software
    /// package version.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">AssociateSbomWithPackageVersion</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "IOTSbomWithPackageVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.AssociateSbomWithPackageVersionResponse")]
    [AWSCmdlet("Calls the AWS IoT AssociateSbomWithPackageVersion API operation.", Operation = new[] {"AssociateSbomWithPackageVersion"}, SelectReturnType = typeof(Amazon.IoT.Model.AssociateSbomWithPackageVersionResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.AssociateSbomWithPackageVersionResponse",
        "This cmdlet returns an Amazon.IoT.Model.AssociateSbomWithPackageVersionResponse object containing multiple properties."
    )]
    public partial class AddIOTSbomWithPackageVersionCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3Location_Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Sbom_S3Location_Bucket")]
        public System.String S3Location_Bucket { get; set; }
        #endregion
        
        #region Parameter S3Location_Key
        /// <summary>
        /// <para>
        /// <para>The S3 key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Sbom_S3Location_Key")]
        public System.String S3Location_Key { get; set; }
        #endregion
        
        #region Parameter PackageName
        /// <summary>
        /// <para>
        /// <para>The name of the new software package.</para>
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
        
        #region Parameter S3Location_Version
        /// <summary>
        /// <para>
        /// <para>The S3 bucket version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Sbom_S3Location_Version")]
        public System.String S3Location_Version { get; set; }
        #endregion
        
        #region Parameter VersionName
        /// <summary>
        /// <para>
        /// <para>The name of the new package version.</para>
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
        public System.String VersionName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique case-sensitive identifier that you can provide to ensure the idempotency
        /// of the request. Don't reuse this client token if a new idempotent request is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.AssociateSbomWithPackageVersionResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.AssociateSbomWithPackageVersionResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VersionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-IOTSbomWithPackageVersion (AssociateSbomWithPackageVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.AssociateSbomWithPackageVersionResponse, AddIOTSbomWithPackageVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.PackageName = this.PackageName;
            #if MODULAR
            if (this.PackageName == null && ParameterWasBound(nameof(this.PackageName)))
            {
                WriteWarning("You are passing $null as a value for parameter PackageName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Location_Bucket = this.S3Location_Bucket;
            context.S3Location_Key = this.S3Location_Key;
            context.S3Location_Version = this.S3Location_Version;
            context.VersionName = this.VersionName;
            #if MODULAR
            if (this.VersionName == null && ParameterWasBound(nameof(this.VersionName)))
            {
                WriteWarning("You are passing $null as a value for parameter VersionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoT.Model.AssociateSbomWithPackageVersionRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.PackageName != null)
            {
                request.PackageName = cmdletContext.PackageName;
            }
            
             // populate Sbom
            var requestSbomIsNull = true;
            request.Sbom = new Amazon.IoT.Model.Sbom();
            Amazon.IoT.Model.S3Location requestSbom_sbom_S3Location = null;
            
             // populate S3Location
            var requestSbom_sbom_S3LocationIsNull = true;
            requestSbom_sbom_S3Location = new Amazon.IoT.Model.S3Location();
            System.String requestSbom_sbom_S3Location_s3Location_Bucket = null;
            if (cmdletContext.S3Location_Bucket != null)
            {
                requestSbom_sbom_S3Location_s3Location_Bucket = cmdletContext.S3Location_Bucket;
            }
            if (requestSbom_sbom_S3Location_s3Location_Bucket != null)
            {
                requestSbom_sbom_S3Location.Bucket = requestSbom_sbom_S3Location_s3Location_Bucket;
                requestSbom_sbom_S3LocationIsNull = false;
            }
            System.String requestSbom_sbom_S3Location_s3Location_Key = null;
            if (cmdletContext.S3Location_Key != null)
            {
                requestSbom_sbom_S3Location_s3Location_Key = cmdletContext.S3Location_Key;
            }
            if (requestSbom_sbom_S3Location_s3Location_Key != null)
            {
                requestSbom_sbom_S3Location.Key = requestSbom_sbom_S3Location_s3Location_Key;
                requestSbom_sbom_S3LocationIsNull = false;
            }
            System.String requestSbom_sbom_S3Location_s3Location_Version = null;
            if (cmdletContext.S3Location_Version != null)
            {
                requestSbom_sbom_S3Location_s3Location_Version = cmdletContext.S3Location_Version;
            }
            if (requestSbom_sbom_S3Location_s3Location_Version != null)
            {
                requestSbom_sbom_S3Location.Version = requestSbom_sbom_S3Location_s3Location_Version;
                requestSbom_sbom_S3LocationIsNull = false;
            }
             // determine if requestSbom_sbom_S3Location should be set to null
            if (requestSbom_sbom_S3LocationIsNull)
            {
                requestSbom_sbom_S3Location = null;
            }
            if (requestSbom_sbom_S3Location != null)
            {
                request.Sbom.S3Location = requestSbom_sbom_S3Location;
                requestSbomIsNull = false;
            }
             // determine if request.Sbom should be set to null
            if (requestSbomIsNull)
            {
                request.Sbom = null;
            }
            if (cmdletContext.VersionName != null)
            {
                request.VersionName = cmdletContext.VersionName;
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
        
        private Amazon.IoT.Model.AssociateSbomWithPackageVersionResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.AssociateSbomWithPackageVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "AssociateSbomWithPackageVersion");
            try
            {
                #if DESKTOP
                return client.AssociateSbomWithPackageVersion(request);
                #elif CORECLR
                return client.AssociateSbomWithPackageVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String PackageName { get; set; }
            public System.String S3Location_Bucket { get; set; }
            public System.String S3Location_Key { get; set; }
            public System.String S3Location_Version { get; set; }
            public System.String VersionName { get; set; }
            public System.Func<Amazon.IoT.Model.AssociateSbomWithPackageVersionResponse, AddIOTSbomWithPackageVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

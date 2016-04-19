/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Sets the versioning state of an existing bucket. To set the versioning state, you
    /// must be the bucket owner.
    /// </summary>
    [Cmdlet("Write", "S3BucketVersioning", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the PutBucketVersioning operation against Amazon Simple Storage Service.", Operation = new[] {"PutBucketVersioning"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the BucketName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.S3.Model.PutBucketVersioningResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteS3BucketVersioningCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter MfaCodes_AuthenticationValue
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MfaCodes_AuthenticationValue { get; set; }
        #endregion
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The name of the bucket to be updated.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter VersioningConfig_EnableMfaDelete
        /// <summary>
        /// <para>
        /// Specifies whether MFA Delete is enabled on this S3 Bucket.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean VersioningConfig_EnableMfaDelete { get; set; }
        #endregion
        
        #region Parameter MfaCodes_SerialNumber
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MfaCodes_SerialNumber { get; set; }
        #endregion
        
        #region Parameter VersioningConfig_Status
        /// <summary>
        /// <para>
        /// Versioning status for the bucket.
        /// Accepted values: Off, Enabled, Suspended.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.S3.VersionStatus")]
        public Amazon.S3.VersionStatus VersioningConfig_Status { get; set; }
        #endregion
        
        #region Parameter UseAccelerateEndpoint
        /// <summary>
        /// Enables S3 accelerate by sending requests to the accelerate endpoint instead of the regular region endpoint.
        /// To use this feature, the bucket name must be DNS compliant and must not contain periods (.). 
        /// </summary>
        [Parameter]
        public SwitchParameter UseAccelerateEndpoint { get; set; }
        
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the BucketName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("BucketName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3BucketVersioning (PutBucketVersioning)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.BucketName = this.BucketName;
            context.MfaCodes_SerialNumber = this.MfaCodes_SerialNumber;
            context.MfaCodes_AuthenticationValue = this.MfaCodes_AuthenticationValue;
            context.VersioningConfig_Status = this.VersioningConfig_Status;
            if (ParameterWasBound("VersioningConfig_EnableMfaDelete"))
                context.VersioningConfig_EnableMfaDelete = this.VersioningConfig_EnableMfaDelete;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.S3.Model.PutBucketVersioningRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            
             // populate MfaCodes
            bool requestMfaCodesIsNull = true;
            request.MfaCodes = new Amazon.S3.Model.MfaCodes();
            System.String requestMfaCodes_mfaCodes_SerialNumber = null;
            if (cmdletContext.MfaCodes_SerialNumber != null)
            {
                requestMfaCodes_mfaCodes_SerialNumber = cmdletContext.MfaCodes_SerialNumber;
            }
            if (requestMfaCodes_mfaCodes_SerialNumber != null)
            {
                request.MfaCodes.SerialNumber = requestMfaCodes_mfaCodes_SerialNumber;
                requestMfaCodesIsNull = false;
            }
            System.String requestMfaCodes_mfaCodes_AuthenticationValue = null;
            if (cmdletContext.MfaCodes_AuthenticationValue != null)
            {
                requestMfaCodes_mfaCodes_AuthenticationValue = cmdletContext.MfaCodes_AuthenticationValue;
            }
            if (requestMfaCodes_mfaCodes_AuthenticationValue != null)
            {
                request.MfaCodes.AuthenticationValue = requestMfaCodes_mfaCodes_AuthenticationValue;
                requestMfaCodesIsNull = false;
            }
             // determine if request.MfaCodes should be set to null
            if (requestMfaCodesIsNull)
            {
                request.MfaCodes = null;
            }
            
             // populate VersioningConfig
            bool requestVersioningConfigIsNull = true;
            request.VersioningConfig = new Amazon.S3.Model.S3BucketVersioningConfig();
            Amazon.S3.VersionStatus requestVersioningConfig_versioningConfig_Status = null;
            if (cmdletContext.VersioningConfig_Status != null)
            {
                requestVersioningConfig_versioningConfig_Status = cmdletContext.VersioningConfig_Status;
            }
            if (requestVersioningConfig_versioningConfig_Status != null)
            {
                request.VersioningConfig.Status = requestVersioningConfig_versioningConfig_Status;
                requestVersioningConfigIsNull = false;
            }
            System.Boolean? requestVersioningConfig_versioningConfig_EnableMfaDelete = null;
            if (cmdletContext.VersioningConfig_EnableMfaDelete != null)
            {
                requestVersioningConfig_versioningConfig_EnableMfaDelete = cmdletContext.VersioningConfig_EnableMfaDelete.Value;
            }
            if (requestVersioningConfig_versioningConfig_EnableMfaDelete != null)
            {
                request.VersioningConfig.EnableMfaDelete = requestVersioningConfig_versioningConfig_EnableMfaDelete.Value;
                requestVersioningConfigIsNull = false;
            }
             // determine if request.VersioningConfig should be set to null
            if (requestVersioningConfigIsNull)
            {
                request.VersioningConfig = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.PutBucketVersioning(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.BucketName;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String BucketName { get; set; }
            public System.String MfaCodes_SerialNumber { get; set; }
            public System.String MfaCodes_AuthenticationValue { get; set; }
            public Amazon.S3.VersionStatus VersioningConfig_Status { get; set; }
            public System.Boolean? VersioningConfig_EnableMfaDelete { get; set; }
        }
        
    }
}

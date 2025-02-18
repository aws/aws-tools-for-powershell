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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Update a field-level encryption profile.
    /// </summary>
    [Cmdlet("Update", "CFFieldLevelEncryptionProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.FieldLevelEncryptionProfile")]
    [AWSCmdlet("Calls the Amazon CloudFront UpdateFieldLevelEncryptionProfile API operation.", Operation = new[] {"UpdateFieldLevelEncryptionProfile"}, SelectReturnType = typeof(Amazon.CloudFront.Model.UpdateFieldLevelEncryptionProfileResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.FieldLevelEncryptionProfile or Amazon.CloudFront.Model.UpdateFieldLevelEncryptionProfileResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.FieldLevelEncryptionProfile object.",
        "The service call response (type Amazon.CloudFront.Model.UpdateFieldLevelEncryptionProfileResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCFFieldLevelEncryptionProfileCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FieldLevelEncryptionProfileConfig_CallerReference
        /// <summary>
        /// <para>
        /// <para>A unique number that ensures that the request can't be replayed.</para>
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
        public System.String FieldLevelEncryptionProfileConfig_CallerReference { get; set; }
        #endregion
        
        #region Parameter FieldLevelEncryptionProfileConfig_Comment
        /// <summary>
        /// <para>
        /// <para>An optional comment for the field-level encryption profile. The comment cannot be
        /// longer than 128 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FieldLevelEncryptionProfileConfig_Comment { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the field-level encryption profile request.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter IfMatch
        /// <summary>
        /// <para>
        /// <para>The value of the <c>ETag</c> header that you received when retrieving the profile
        /// identity to update. For example: <c>E2QWRUHAPOMQZL</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IfMatch { get; set; }
        #endregion
        
        #region Parameter EncryptionEntities_Item
        /// <summary>
        /// <para>
        /// <para>An array of field patterns in a field-level encryption content type-profile mapping.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FieldLevelEncryptionProfileConfig_EncryptionEntities_Items")]
        public Amazon.CloudFront.Model.EncryptionEntity[] EncryptionEntities_Item { get; set; }
        #endregion
        
        #region Parameter FieldLevelEncryptionProfileConfig_Name
        /// <summary>
        /// <para>
        /// <para>Profile name for the field-level encryption profile.</para>
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
        public System.String FieldLevelEncryptionProfileConfig_Name { get; set; }
        #endregion
        
        #region Parameter EncryptionEntities_Quantity
        /// <summary>
        /// <para>
        /// <para>Number of field pattern items in a field-level encryption content type-profile mapping.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("FieldLevelEncryptionProfileConfig_EncryptionEntities_Quantity")]
        public System.Int32? EncryptionEntities_Quantity { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FieldLevelEncryptionProfile'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.UpdateFieldLevelEncryptionProfileResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.UpdateFieldLevelEncryptionProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FieldLevelEncryptionProfile";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CFFieldLevelEncryptionProfile (UpdateFieldLevelEncryptionProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.UpdateFieldLevelEncryptionProfileResponse, UpdateCFFieldLevelEncryptionProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FieldLevelEncryptionProfileConfig_CallerReference = this.FieldLevelEncryptionProfileConfig_CallerReference;
            #if MODULAR
            if (this.FieldLevelEncryptionProfileConfig_CallerReference == null && ParameterWasBound(nameof(this.FieldLevelEncryptionProfileConfig_CallerReference)))
            {
                WriteWarning("You are passing $null as a value for parameter FieldLevelEncryptionProfileConfig_CallerReference which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FieldLevelEncryptionProfileConfig_Comment = this.FieldLevelEncryptionProfileConfig_Comment;
            if (this.EncryptionEntities_Item != null)
            {
                context.EncryptionEntities_Item = new List<Amazon.CloudFront.Model.EncryptionEntity>(this.EncryptionEntities_Item);
            }
            context.EncryptionEntities_Quantity = this.EncryptionEntities_Quantity;
            #if MODULAR
            if (this.EncryptionEntities_Quantity == null && ParameterWasBound(nameof(this.EncryptionEntities_Quantity)))
            {
                WriteWarning("You are passing $null as a value for parameter EncryptionEntities_Quantity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FieldLevelEncryptionProfileConfig_Name = this.FieldLevelEncryptionProfileConfig_Name;
            #if MODULAR
            if (this.FieldLevelEncryptionProfileConfig_Name == null && ParameterWasBound(nameof(this.FieldLevelEncryptionProfileConfig_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter FieldLevelEncryptionProfileConfig_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IfMatch = this.IfMatch;
            
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
            var request = new Amazon.CloudFront.Model.UpdateFieldLevelEncryptionProfileRequest();
            
            
             // populate FieldLevelEncryptionProfileConfig
            var requestFieldLevelEncryptionProfileConfigIsNull = true;
            request.FieldLevelEncryptionProfileConfig = new Amazon.CloudFront.Model.FieldLevelEncryptionProfileConfig();
            System.String requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_CallerReference = null;
            if (cmdletContext.FieldLevelEncryptionProfileConfig_CallerReference != null)
            {
                requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_CallerReference = cmdletContext.FieldLevelEncryptionProfileConfig_CallerReference;
            }
            if (requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_CallerReference != null)
            {
                request.FieldLevelEncryptionProfileConfig.CallerReference = requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_CallerReference;
                requestFieldLevelEncryptionProfileConfigIsNull = false;
            }
            System.String requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_Comment = null;
            if (cmdletContext.FieldLevelEncryptionProfileConfig_Comment != null)
            {
                requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_Comment = cmdletContext.FieldLevelEncryptionProfileConfig_Comment;
            }
            if (requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_Comment != null)
            {
                request.FieldLevelEncryptionProfileConfig.Comment = requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_Comment;
                requestFieldLevelEncryptionProfileConfigIsNull = false;
            }
            System.String requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_Name = null;
            if (cmdletContext.FieldLevelEncryptionProfileConfig_Name != null)
            {
                requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_Name = cmdletContext.FieldLevelEncryptionProfileConfig_Name;
            }
            if (requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_Name != null)
            {
                request.FieldLevelEncryptionProfileConfig.Name = requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_Name;
                requestFieldLevelEncryptionProfileConfigIsNull = false;
            }
            Amazon.CloudFront.Model.EncryptionEntities requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_EncryptionEntities = null;
            
             // populate EncryptionEntities
            var requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_EncryptionEntitiesIsNull = true;
            requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_EncryptionEntities = new Amazon.CloudFront.Model.EncryptionEntities();
            List<Amazon.CloudFront.Model.EncryptionEntity> requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_EncryptionEntities_encryptionEntities_Item = null;
            if (cmdletContext.EncryptionEntities_Item != null)
            {
                requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_EncryptionEntities_encryptionEntities_Item = cmdletContext.EncryptionEntities_Item;
            }
            if (requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_EncryptionEntities_encryptionEntities_Item != null)
            {
                requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_EncryptionEntities.Items = requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_EncryptionEntities_encryptionEntities_Item;
                requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_EncryptionEntitiesIsNull = false;
            }
            System.Int32? requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_EncryptionEntities_encryptionEntities_Quantity = null;
            if (cmdletContext.EncryptionEntities_Quantity != null)
            {
                requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_EncryptionEntities_encryptionEntities_Quantity = cmdletContext.EncryptionEntities_Quantity.Value;
            }
            if (requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_EncryptionEntities_encryptionEntities_Quantity != null)
            {
                requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_EncryptionEntities.Quantity = requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_EncryptionEntities_encryptionEntities_Quantity.Value;
                requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_EncryptionEntitiesIsNull = false;
            }
             // determine if requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_EncryptionEntities should be set to null
            if (requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_EncryptionEntitiesIsNull)
            {
                requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_EncryptionEntities = null;
            }
            if (requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_EncryptionEntities != null)
            {
                request.FieldLevelEncryptionProfileConfig.EncryptionEntities = requestFieldLevelEncryptionProfileConfig_fieldLevelEncryptionProfileConfig_EncryptionEntities;
                requestFieldLevelEncryptionProfileConfigIsNull = false;
            }
             // determine if request.FieldLevelEncryptionProfileConfig should be set to null
            if (requestFieldLevelEncryptionProfileConfigIsNull)
            {
                request.FieldLevelEncryptionProfileConfig = null;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.IfMatch != null)
            {
                request.IfMatch = cmdletContext.IfMatch;
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
        
        private Amazon.CloudFront.Model.UpdateFieldLevelEncryptionProfileResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.UpdateFieldLevelEncryptionProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "UpdateFieldLevelEncryptionProfile");
            try
            {
                return client.UpdateFieldLevelEncryptionProfileAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String FieldLevelEncryptionProfileConfig_CallerReference { get; set; }
            public System.String FieldLevelEncryptionProfileConfig_Comment { get; set; }
            public List<Amazon.CloudFront.Model.EncryptionEntity> EncryptionEntities_Item { get; set; }
            public System.Int32? EncryptionEntities_Quantity { get; set; }
            public System.String FieldLevelEncryptionProfileConfig_Name { get; set; }
            public System.String Id { get; set; }
            public System.String IfMatch { get; set; }
            public System.Func<Amazon.CloudFront.Model.UpdateFieldLevelEncryptionProfileResponse, UpdateCFFieldLevelEncryptionProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FieldLevelEncryptionProfile;
        }
        
    }
}

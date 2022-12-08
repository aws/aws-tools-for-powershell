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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Create a field-level encryption profile.
    /// </summary>
    [Cmdlet("New", "CFFieldLevelEncryptionProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.CreateFieldLevelEncryptionProfileResponse")]
    [AWSCmdlet("Calls the Amazon CloudFront CreateFieldLevelEncryptionProfile API operation.", Operation = new[] {"CreateFieldLevelEncryptionProfile"}, SelectReturnType = typeof(Amazon.CloudFront.Model.CreateFieldLevelEncryptionProfileResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CreateFieldLevelEncryptionProfileResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.CreateFieldLevelEncryptionProfileResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCFFieldLevelEncryptionProfileCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
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
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String FieldLevelEncryptionProfileConfig_Name { get; set; }
        #endregion
        
        #region Parameter EncryptionEntities_Quantity
        /// <summary>
        /// <para>
        /// <para>Number of field pattern items in a field-level encryption content type-profile mapping.
        /// </para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.CreateFieldLevelEncryptionProfileResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.CreateFieldLevelEncryptionProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FieldLevelEncryptionProfileConfig_Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FieldLevelEncryptionProfileConfig_Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FieldLevelEncryptionProfileConfig_Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FieldLevelEncryptionProfileConfig_Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CFFieldLevelEncryptionProfile (CreateFieldLevelEncryptionProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.CreateFieldLevelEncryptionProfileResponse, NewCFFieldLevelEncryptionProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FieldLevelEncryptionProfileConfig_Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            var request = new Amazon.CloudFront.Model.CreateFieldLevelEncryptionProfileRequest();
            
            
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
        
        private Amazon.CloudFront.Model.CreateFieldLevelEncryptionProfileResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.CreateFieldLevelEncryptionProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "CreateFieldLevelEncryptionProfile");
            try
            {
                #if DESKTOP
                return client.CreateFieldLevelEncryptionProfile(request);
                #elif CORECLR
                return client.CreateFieldLevelEncryptionProfileAsync(request).GetAwaiter().GetResult();
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
            public System.String FieldLevelEncryptionProfileConfig_CallerReference { get; set; }
            public System.String FieldLevelEncryptionProfileConfig_Comment { get; set; }
            public List<Amazon.CloudFront.Model.EncryptionEntity> EncryptionEntities_Item { get; set; }
            public System.Int32? EncryptionEntities_Quantity { get; set; }
            public System.String FieldLevelEncryptionProfileConfig_Name { get; set; }
            public System.Func<Amazon.CloudFront.Model.CreateFieldLevelEncryptionProfileResponse, NewCFFieldLevelEncryptionProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

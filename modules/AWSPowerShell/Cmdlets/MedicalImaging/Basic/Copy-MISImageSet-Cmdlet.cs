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
using Amazon.MedicalImaging;
using Amazon.MedicalImaging.Model;

namespace Amazon.PowerShell.Cmdlets.MIS
{
    /// <summary>
    /// Copy an image set.
    /// </summary>
    [Cmdlet("Copy", "MISImageSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MedicalImaging.Model.CopyImageSetResponse")]
    [AWSCmdlet("Calls the Amazon Medical Imaging Service CopyImageSet API operation.", Operation = new[] {"CopyImageSet"}, SelectReturnType = typeof(Amazon.MedicalImaging.Model.CopyImageSetResponse))]
    [AWSCmdletOutput("Amazon.MedicalImaging.Model.CopyImageSetResponse",
        "This cmdlet returns an Amazon.MedicalImaging.Model.CopyImageSetResponse object containing multiple properties."
    )]
    public partial class CopyMISImageSetCmdlet : AmazonMedicalImagingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DICOMCopies_CopiableAttribute
        /// <summary>
        /// <para>
        /// <para>The JSON string used to specify a subset of SOP Instances to copy from source to destination
        /// image set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CopyImageSetInformation_SourceImageSet_DICOMCopies_CopiableAttributes")]
        public System.String DICOMCopies_CopiableAttribute { get; set; }
        #endregion
        
        #region Parameter DatastoreId
        /// <summary>
        /// <para>
        /// <para>The data store identifier.</para>
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
        public System.String DatastoreId { get; set; }
        #endregion
        
        #region Parameter ForceCopy
        /// <summary>
        /// <para>
        /// <para>Setting this flag will force the <c>CopyImageSet</c> operation, even if Patient, Study,
        /// or Series level metadata are mismatched across the <c>sourceImageSet</c> and <c>destinationImageSet</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ForceCopy { get; set; }
        #endregion
        
        #region Parameter DestinationImageSet_ImageSetId
        /// <summary>
        /// <para>
        /// <para>The image set identifier for the destination image set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CopyImageSetInformation_DestinationImageSet_ImageSetId")]
        public System.String DestinationImageSet_ImageSetId { get; set; }
        #endregion
        
        #region Parameter DestinationImageSet_LatestVersionId
        /// <summary>
        /// <para>
        /// <para>The latest version identifier for the destination image set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CopyImageSetInformation_DestinationImageSet_LatestVersionId")]
        public System.String DestinationImageSet_LatestVersionId { get; set; }
        #endregion
        
        #region Parameter SourceImageSet_LatestVersionId
        /// <summary>
        /// <para>
        /// <para>The latest version identifier for the source image set.</para>
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
        [Alias("CopyImageSetInformation_SourceImageSet_LatestVersionId")]
        public System.String SourceImageSet_LatestVersionId { get; set; }
        #endregion
        
        #region Parameter SourceImageSetId
        /// <summary>
        /// <para>
        /// <para>The source image set identifier.</para>
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
        public System.String SourceImageSetId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MedicalImaging.Model.CopyImageSetResponse).
        /// Specifying the name of a property of type Amazon.MedicalImaging.Model.CopyImageSetResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatastoreId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-MISImageSet (CopyImageSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MedicalImaging.Model.CopyImageSetResponse, CopyMISImageSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DestinationImageSet_ImageSetId = this.DestinationImageSet_ImageSetId;
            context.DestinationImageSet_LatestVersionId = this.DestinationImageSet_LatestVersionId;
            context.DICOMCopies_CopiableAttribute = this.DICOMCopies_CopiableAttribute;
            context.SourceImageSet_LatestVersionId = this.SourceImageSet_LatestVersionId;
            #if MODULAR
            if (this.SourceImageSet_LatestVersionId == null && ParameterWasBound(nameof(this.SourceImageSet_LatestVersionId)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceImageSet_LatestVersionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DatastoreId = this.DatastoreId;
            #if MODULAR
            if (this.DatastoreId == null && ParameterWasBound(nameof(this.DatastoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter DatastoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ForceCopy = this.ForceCopy;
            context.SourceImageSetId = this.SourceImageSetId;
            #if MODULAR
            if (this.SourceImageSetId == null && ParameterWasBound(nameof(this.SourceImageSetId)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceImageSetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MedicalImaging.Model.CopyImageSetRequest();
            
            
             // populate CopyImageSetInformation
            var requestCopyImageSetInformationIsNull = true;
            request.CopyImageSetInformation = new Amazon.MedicalImaging.Model.CopyImageSetInformation();
            Amazon.MedicalImaging.Model.CopyDestinationImageSet requestCopyImageSetInformation_copyImageSetInformation_DestinationImageSet = null;
            
             // populate DestinationImageSet
            var requestCopyImageSetInformation_copyImageSetInformation_DestinationImageSetIsNull = true;
            requestCopyImageSetInformation_copyImageSetInformation_DestinationImageSet = new Amazon.MedicalImaging.Model.CopyDestinationImageSet();
            System.String requestCopyImageSetInformation_copyImageSetInformation_DestinationImageSet_destinationImageSet_ImageSetId = null;
            if (cmdletContext.DestinationImageSet_ImageSetId != null)
            {
                requestCopyImageSetInformation_copyImageSetInformation_DestinationImageSet_destinationImageSet_ImageSetId = cmdletContext.DestinationImageSet_ImageSetId;
            }
            if (requestCopyImageSetInformation_copyImageSetInformation_DestinationImageSet_destinationImageSet_ImageSetId != null)
            {
                requestCopyImageSetInformation_copyImageSetInformation_DestinationImageSet.ImageSetId = requestCopyImageSetInformation_copyImageSetInformation_DestinationImageSet_destinationImageSet_ImageSetId;
                requestCopyImageSetInformation_copyImageSetInformation_DestinationImageSetIsNull = false;
            }
            System.String requestCopyImageSetInformation_copyImageSetInformation_DestinationImageSet_destinationImageSet_LatestVersionId = null;
            if (cmdletContext.DestinationImageSet_LatestVersionId != null)
            {
                requestCopyImageSetInformation_copyImageSetInformation_DestinationImageSet_destinationImageSet_LatestVersionId = cmdletContext.DestinationImageSet_LatestVersionId;
            }
            if (requestCopyImageSetInformation_copyImageSetInformation_DestinationImageSet_destinationImageSet_LatestVersionId != null)
            {
                requestCopyImageSetInformation_copyImageSetInformation_DestinationImageSet.LatestVersionId = requestCopyImageSetInformation_copyImageSetInformation_DestinationImageSet_destinationImageSet_LatestVersionId;
                requestCopyImageSetInformation_copyImageSetInformation_DestinationImageSetIsNull = false;
            }
             // determine if requestCopyImageSetInformation_copyImageSetInformation_DestinationImageSet should be set to null
            if (requestCopyImageSetInformation_copyImageSetInformation_DestinationImageSetIsNull)
            {
                requestCopyImageSetInformation_copyImageSetInformation_DestinationImageSet = null;
            }
            if (requestCopyImageSetInformation_copyImageSetInformation_DestinationImageSet != null)
            {
                request.CopyImageSetInformation.DestinationImageSet = requestCopyImageSetInformation_copyImageSetInformation_DestinationImageSet;
                requestCopyImageSetInformationIsNull = false;
            }
            Amazon.MedicalImaging.Model.CopySourceImageSetInformation requestCopyImageSetInformation_copyImageSetInformation_SourceImageSet = null;
            
             // populate SourceImageSet
            var requestCopyImageSetInformation_copyImageSetInformation_SourceImageSetIsNull = true;
            requestCopyImageSetInformation_copyImageSetInformation_SourceImageSet = new Amazon.MedicalImaging.Model.CopySourceImageSetInformation();
            System.String requestCopyImageSetInformation_copyImageSetInformation_SourceImageSet_sourceImageSet_LatestVersionId = null;
            if (cmdletContext.SourceImageSet_LatestVersionId != null)
            {
                requestCopyImageSetInformation_copyImageSetInformation_SourceImageSet_sourceImageSet_LatestVersionId = cmdletContext.SourceImageSet_LatestVersionId;
            }
            if (requestCopyImageSetInformation_copyImageSetInformation_SourceImageSet_sourceImageSet_LatestVersionId != null)
            {
                requestCopyImageSetInformation_copyImageSetInformation_SourceImageSet.LatestVersionId = requestCopyImageSetInformation_copyImageSetInformation_SourceImageSet_sourceImageSet_LatestVersionId;
                requestCopyImageSetInformation_copyImageSetInformation_SourceImageSetIsNull = false;
            }
            Amazon.MedicalImaging.Model.MetadataCopies requestCopyImageSetInformation_copyImageSetInformation_SourceImageSet_copyImageSetInformation_SourceImageSet_DICOMCopies = null;
            
             // populate DICOMCopies
            var requestCopyImageSetInformation_copyImageSetInformation_SourceImageSet_copyImageSetInformation_SourceImageSet_DICOMCopiesIsNull = true;
            requestCopyImageSetInformation_copyImageSetInformation_SourceImageSet_copyImageSetInformation_SourceImageSet_DICOMCopies = new Amazon.MedicalImaging.Model.MetadataCopies();
            System.String requestCopyImageSetInformation_copyImageSetInformation_SourceImageSet_copyImageSetInformation_SourceImageSet_DICOMCopies_dICOMCopies_CopiableAttribute = null;
            if (cmdletContext.DICOMCopies_CopiableAttribute != null)
            {
                requestCopyImageSetInformation_copyImageSetInformation_SourceImageSet_copyImageSetInformation_SourceImageSet_DICOMCopies_dICOMCopies_CopiableAttribute = cmdletContext.DICOMCopies_CopiableAttribute;
            }
            if (requestCopyImageSetInformation_copyImageSetInformation_SourceImageSet_copyImageSetInformation_SourceImageSet_DICOMCopies_dICOMCopies_CopiableAttribute != null)
            {
                requestCopyImageSetInformation_copyImageSetInformation_SourceImageSet_copyImageSetInformation_SourceImageSet_DICOMCopies.CopiableAttributes = requestCopyImageSetInformation_copyImageSetInformation_SourceImageSet_copyImageSetInformation_SourceImageSet_DICOMCopies_dICOMCopies_CopiableAttribute;
                requestCopyImageSetInformation_copyImageSetInformation_SourceImageSet_copyImageSetInformation_SourceImageSet_DICOMCopiesIsNull = false;
            }
             // determine if requestCopyImageSetInformation_copyImageSetInformation_SourceImageSet_copyImageSetInformation_SourceImageSet_DICOMCopies should be set to null
            if (requestCopyImageSetInformation_copyImageSetInformation_SourceImageSet_copyImageSetInformation_SourceImageSet_DICOMCopiesIsNull)
            {
                requestCopyImageSetInformation_copyImageSetInformation_SourceImageSet_copyImageSetInformation_SourceImageSet_DICOMCopies = null;
            }
            if (requestCopyImageSetInformation_copyImageSetInformation_SourceImageSet_copyImageSetInformation_SourceImageSet_DICOMCopies != null)
            {
                requestCopyImageSetInformation_copyImageSetInformation_SourceImageSet.DICOMCopies = requestCopyImageSetInformation_copyImageSetInformation_SourceImageSet_copyImageSetInformation_SourceImageSet_DICOMCopies;
                requestCopyImageSetInformation_copyImageSetInformation_SourceImageSetIsNull = false;
            }
             // determine if requestCopyImageSetInformation_copyImageSetInformation_SourceImageSet should be set to null
            if (requestCopyImageSetInformation_copyImageSetInformation_SourceImageSetIsNull)
            {
                requestCopyImageSetInformation_copyImageSetInformation_SourceImageSet = null;
            }
            if (requestCopyImageSetInformation_copyImageSetInformation_SourceImageSet != null)
            {
                request.CopyImageSetInformation.SourceImageSet = requestCopyImageSetInformation_copyImageSetInformation_SourceImageSet;
                requestCopyImageSetInformationIsNull = false;
            }
             // determine if request.CopyImageSetInformation should be set to null
            if (requestCopyImageSetInformationIsNull)
            {
                request.CopyImageSetInformation = null;
            }
            if (cmdletContext.DatastoreId != null)
            {
                request.DatastoreId = cmdletContext.DatastoreId;
            }
            if (cmdletContext.ForceCopy != null)
            {
                request.Force = cmdletContext.ForceCopy.Value;
            }
            if (cmdletContext.SourceImageSetId != null)
            {
                request.SourceImageSetId = cmdletContext.SourceImageSetId;
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
        
        private Amazon.MedicalImaging.Model.CopyImageSetResponse CallAWSServiceOperation(IAmazonMedicalImaging client, Amazon.MedicalImaging.Model.CopyImageSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Medical Imaging Service", "CopyImageSet");
            try
            {
                #if DESKTOP
                return client.CopyImageSet(request);
                #elif CORECLR
                return client.CopyImageSetAsync(request).GetAwaiter().GetResult();
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
            public System.String DestinationImageSet_ImageSetId { get; set; }
            public System.String DestinationImageSet_LatestVersionId { get; set; }
            public System.String DICOMCopies_CopiableAttribute { get; set; }
            public System.String SourceImageSet_LatestVersionId { get; set; }
            public System.String DatastoreId { get; set; }
            public System.Boolean? ForceCopy { get; set; }
            public System.String SourceImageSetId { get; set; }
            public System.Func<Amazon.MedicalImaging.Model.CopyImageSetResponse, CopyMISImageSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

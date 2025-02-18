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
using Amazon.B2bi;
using Amazon.B2bi.Model;

namespace Amazon.PowerShell.Cmdlets.B2BI
{
    /// <summary>
    /// Updates some of the parameters for a capability, based on the specified parameters.
    /// A trading capability contains the information required to transform incoming EDI documents
    /// into JSON or XML outputs.
    /// </summary>
    [Cmdlet("Update", "B2BICapability", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.B2bi.Model.UpdateCapabilityResponse")]
    [AWSCmdlet("Calls the AWS B2B Data Interchange UpdateCapability API operation.", Operation = new[] {"UpdateCapability"}, SelectReturnType = typeof(Amazon.B2bi.Model.UpdateCapabilityResponse))]
    [AWSCmdletOutput("Amazon.B2bi.Model.UpdateCapabilityResponse",
        "This cmdlet returns an Amazon.B2bi.Model.UpdateCapabilityResponse object containing multiple properties."
    )]
    public partial class UpdateB2BICapabilityCmdlet : AmazonB2biClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter InputLocation_BucketName
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Edi_InputLocation_BucketName")]
        public System.String InputLocation_BucketName { get; set; }
        #endregion
        
        #region Parameter OutputLocation_BucketName
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Edi_OutputLocation_BucketName")]
        public System.String OutputLocation_BucketName { get; set; }
        #endregion
        
        #region Parameter Edi_CapabilityDirection
        /// <summary>
        /// <para>
        /// <para>Specifies whether this is capability is for inbound or outbound transformations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Edi_CapabilityDirection")]
        [AWSConstantClassSource("Amazon.B2bi.CapabilityDirection")]
        public Amazon.B2bi.CapabilityDirection Edi_CapabilityDirection { get; set; }
        #endregion
        
        #region Parameter CapabilityId
        /// <summary>
        /// <para>
        /// <para>Specifies a system-assigned unique identifier for the capability.</para>
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
        public System.String CapabilityId { get; set; }
        #endregion
        
        #region Parameter InstructionsDocument
        /// <summary>
        /// <para>
        /// <para>Specifies one or more locations in Amazon S3, each specifying an EDI document that
        /// can be used with this capability. Each item contains the name of the bucket and the
        /// key, to identify the document's location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstructionsDocuments")]
        public Amazon.B2bi.Model.S3Location[] InstructionsDocument { get; set; }
        #endregion
        
        #region Parameter InputLocation_Key
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon S3 key for the file location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Edi_InputLocation_Key")]
        public System.String InputLocation_Key { get; set; }
        #endregion
        
        #region Parameter OutputLocation_Key
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon S3 key for the file location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Edi_OutputLocation_Key")]
        public System.String OutputLocation_Key { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Specifies a new name for the capability, to replace the existing name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter X12Details_TransactionSet
        /// <summary>
        /// <para>
        /// <para>Returns an enumerated type where each value identifies an X12 transaction set. Transaction
        /// sets are maintained by the X12 Accredited Standards Committee.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Edi_Type_X12Details_TransactionSet")]
        [AWSConstantClassSource("Amazon.B2bi.X12TransactionSet")]
        public Amazon.B2bi.X12TransactionSet X12Details_TransactionSet { get; set; }
        #endregion
        
        #region Parameter Edi_TransformerId
        /// <summary>
        /// <para>
        /// <para>Returns the system-assigned unique identifier for the transformer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Edi_TransformerId")]
        public System.String Edi_TransformerId { get; set; }
        #endregion
        
        #region Parameter X12Details_Version
        /// <summary>
        /// <para>
        /// <para>Returns the version to use for the specified X12 transaction set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Edi_Type_X12Details_Version")]
        [AWSConstantClassSource("Amazon.B2bi.X12Version")]
        public Amazon.B2bi.X12Version X12Details_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.B2bi.Model.UpdateCapabilityResponse).
        /// Specifying the name of a property of type Amazon.B2bi.Model.UpdateCapabilityResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CapabilityId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-B2BICapability (UpdateCapability)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.B2bi.Model.UpdateCapabilityResponse, UpdateB2BICapabilityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CapabilityId = this.CapabilityId;
            #if MODULAR
            if (this.CapabilityId == null && ParameterWasBound(nameof(this.CapabilityId)))
            {
                WriteWarning("You are passing $null as a value for parameter CapabilityId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Edi_CapabilityDirection = this.Edi_CapabilityDirection;
            context.InputLocation_BucketName = this.InputLocation_BucketName;
            context.InputLocation_Key = this.InputLocation_Key;
            context.OutputLocation_BucketName = this.OutputLocation_BucketName;
            context.OutputLocation_Key = this.OutputLocation_Key;
            context.Edi_TransformerId = this.Edi_TransformerId;
            context.X12Details_TransactionSet = this.X12Details_TransactionSet;
            context.X12Details_Version = this.X12Details_Version;
            if (this.InstructionsDocument != null)
            {
                context.InstructionsDocument = new List<Amazon.B2bi.Model.S3Location>(this.InstructionsDocument);
            }
            context.Name = this.Name;
            
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
            var request = new Amazon.B2bi.Model.UpdateCapabilityRequest();
            
            if (cmdletContext.CapabilityId != null)
            {
                request.CapabilityId = cmdletContext.CapabilityId;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.B2bi.Model.CapabilityConfiguration();
            Amazon.B2bi.Model.EdiConfiguration requestConfiguration_configuration_Edi = null;
            
             // populate Edi
            var requestConfiguration_configuration_EdiIsNull = true;
            requestConfiguration_configuration_Edi = new Amazon.B2bi.Model.EdiConfiguration();
            Amazon.B2bi.CapabilityDirection requestConfiguration_configuration_Edi_edi_CapabilityDirection = null;
            if (cmdletContext.Edi_CapabilityDirection != null)
            {
                requestConfiguration_configuration_Edi_edi_CapabilityDirection = cmdletContext.Edi_CapabilityDirection;
            }
            if (requestConfiguration_configuration_Edi_edi_CapabilityDirection != null)
            {
                requestConfiguration_configuration_Edi.CapabilityDirection = requestConfiguration_configuration_Edi_edi_CapabilityDirection;
                requestConfiguration_configuration_EdiIsNull = false;
            }
            System.String requestConfiguration_configuration_Edi_edi_TransformerId = null;
            if (cmdletContext.Edi_TransformerId != null)
            {
                requestConfiguration_configuration_Edi_edi_TransformerId = cmdletContext.Edi_TransformerId;
            }
            if (requestConfiguration_configuration_Edi_edi_TransformerId != null)
            {
                requestConfiguration_configuration_Edi.TransformerId = requestConfiguration_configuration_Edi_edi_TransformerId;
                requestConfiguration_configuration_EdiIsNull = false;
            }
            Amazon.B2bi.Model.EdiType requestConfiguration_configuration_Edi_configuration_Edi_Type = null;
            
             // populate Type
            var requestConfiguration_configuration_Edi_configuration_Edi_TypeIsNull = true;
            requestConfiguration_configuration_Edi_configuration_Edi_Type = new Amazon.B2bi.Model.EdiType();
            Amazon.B2bi.Model.X12Details requestConfiguration_configuration_Edi_configuration_Edi_Type_configuration_Edi_Type_X12Details = null;
            
             // populate X12Details
            var requestConfiguration_configuration_Edi_configuration_Edi_Type_configuration_Edi_Type_X12DetailsIsNull = true;
            requestConfiguration_configuration_Edi_configuration_Edi_Type_configuration_Edi_Type_X12Details = new Amazon.B2bi.Model.X12Details();
            Amazon.B2bi.X12TransactionSet requestConfiguration_configuration_Edi_configuration_Edi_Type_configuration_Edi_Type_X12Details_x12Details_TransactionSet = null;
            if (cmdletContext.X12Details_TransactionSet != null)
            {
                requestConfiguration_configuration_Edi_configuration_Edi_Type_configuration_Edi_Type_X12Details_x12Details_TransactionSet = cmdletContext.X12Details_TransactionSet;
            }
            if (requestConfiguration_configuration_Edi_configuration_Edi_Type_configuration_Edi_Type_X12Details_x12Details_TransactionSet != null)
            {
                requestConfiguration_configuration_Edi_configuration_Edi_Type_configuration_Edi_Type_X12Details.TransactionSet = requestConfiguration_configuration_Edi_configuration_Edi_Type_configuration_Edi_Type_X12Details_x12Details_TransactionSet;
                requestConfiguration_configuration_Edi_configuration_Edi_Type_configuration_Edi_Type_X12DetailsIsNull = false;
            }
            Amazon.B2bi.X12Version requestConfiguration_configuration_Edi_configuration_Edi_Type_configuration_Edi_Type_X12Details_x12Details_Version = null;
            if (cmdletContext.X12Details_Version != null)
            {
                requestConfiguration_configuration_Edi_configuration_Edi_Type_configuration_Edi_Type_X12Details_x12Details_Version = cmdletContext.X12Details_Version;
            }
            if (requestConfiguration_configuration_Edi_configuration_Edi_Type_configuration_Edi_Type_X12Details_x12Details_Version != null)
            {
                requestConfiguration_configuration_Edi_configuration_Edi_Type_configuration_Edi_Type_X12Details.Version = requestConfiguration_configuration_Edi_configuration_Edi_Type_configuration_Edi_Type_X12Details_x12Details_Version;
                requestConfiguration_configuration_Edi_configuration_Edi_Type_configuration_Edi_Type_X12DetailsIsNull = false;
            }
             // determine if requestConfiguration_configuration_Edi_configuration_Edi_Type_configuration_Edi_Type_X12Details should be set to null
            if (requestConfiguration_configuration_Edi_configuration_Edi_Type_configuration_Edi_Type_X12DetailsIsNull)
            {
                requestConfiguration_configuration_Edi_configuration_Edi_Type_configuration_Edi_Type_X12Details = null;
            }
            if (requestConfiguration_configuration_Edi_configuration_Edi_Type_configuration_Edi_Type_X12Details != null)
            {
                requestConfiguration_configuration_Edi_configuration_Edi_Type.X12Details = requestConfiguration_configuration_Edi_configuration_Edi_Type_configuration_Edi_Type_X12Details;
                requestConfiguration_configuration_Edi_configuration_Edi_TypeIsNull = false;
            }
             // determine if requestConfiguration_configuration_Edi_configuration_Edi_Type should be set to null
            if (requestConfiguration_configuration_Edi_configuration_Edi_TypeIsNull)
            {
                requestConfiguration_configuration_Edi_configuration_Edi_Type = null;
            }
            if (requestConfiguration_configuration_Edi_configuration_Edi_Type != null)
            {
                requestConfiguration_configuration_Edi.Type = requestConfiguration_configuration_Edi_configuration_Edi_Type;
                requestConfiguration_configuration_EdiIsNull = false;
            }
            Amazon.B2bi.Model.S3Location requestConfiguration_configuration_Edi_configuration_Edi_InputLocation = null;
            
             // populate InputLocation
            var requestConfiguration_configuration_Edi_configuration_Edi_InputLocationIsNull = true;
            requestConfiguration_configuration_Edi_configuration_Edi_InputLocation = new Amazon.B2bi.Model.S3Location();
            System.String requestConfiguration_configuration_Edi_configuration_Edi_InputLocation_inputLocation_BucketName = null;
            if (cmdletContext.InputLocation_BucketName != null)
            {
                requestConfiguration_configuration_Edi_configuration_Edi_InputLocation_inputLocation_BucketName = cmdletContext.InputLocation_BucketName;
            }
            if (requestConfiguration_configuration_Edi_configuration_Edi_InputLocation_inputLocation_BucketName != null)
            {
                requestConfiguration_configuration_Edi_configuration_Edi_InputLocation.BucketName = requestConfiguration_configuration_Edi_configuration_Edi_InputLocation_inputLocation_BucketName;
                requestConfiguration_configuration_Edi_configuration_Edi_InputLocationIsNull = false;
            }
            System.String requestConfiguration_configuration_Edi_configuration_Edi_InputLocation_inputLocation_Key = null;
            if (cmdletContext.InputLocation_Key != null)
            {
                requestConfiguration_configuration_Edi_configuration_Edi_InputLocation_inputLocation_Key = cmdletContext.InputLocation_Key;
            }
            if (requestConfiguration_configuration_Edi_configuration_Edi_InputLocation_inputLocation_Key != null)
            {
                requestConfiguration_configuration_Edi_configuration_Edi_InputLocation.Key = requestConfiguration_configuration_Edi_configuration_Edi_InputLocation_inputLocation_Key;
                requestConfiguration_configuration_Edi_configuration_Edi_InputLocationIsNull = false;
            }
             // determine if requestConfiguration_configuration_Edi_configuration_Edi_InputLocation should be set to null
            if (requestConfiguration_configuration_Edi_configuration_Edi_InputLocationIsNull)
            {
                requestConfiguration_configuration_Edi_configuration_Edi_InputLocation = null;
            }
            if (requestConfiguration_configuration_Edi_configuration_Edi_InputLocation != null)
            {
                requestConfiguration_configuration_Edi.InputLocation = requestConfiguration_configuration_Edi_configuration_Edi_InputLocation;
                requestConfiguration_configuration_EdiIsNull = false;
            }
            Amazon.B2bi.Model.S3Location requestConfiguration_configuration_Edi_configuration_Edi_OutputLocation = null;
            
             // populate OutputLocation
            var requestConfiguration_configuration_Edi_configuration_Edi_OutputLocationIsNull = true;
            requestConfiguration_configuration_Edi_configuration_Edi_OutputLocation = new Amazon.B2bi.Model.S3Location();
            System.String requestConfiguration_configuration_Edi_configuration_Edi_OutputLocation_outputLocation_BucketName = null;
            if (cmdletContext.OutputLocation_BucketName != null)
            {
                requestConfiguration_configuration_Edi_configuration_Edi_OutputLocation_outputLocation_BucketName = cmdletContext.OutputLocation_BucketName;
            }
            if (requestConfiguration_configuration_Edi_configuration_Edi_OutputLocation_outputLocation_BucketName != null)
            {
                requestConfiguration_configuration_Edi_configuration_Edi_OutputLocation.BucketName = requestConfiguration_configuration_Edi_configuration_Edi_OutputLocation_outputLocation_BucketName;
                requestConfiguration_configuration_Edi_configuration_Edi_OutputLocationIsNull = false;
            }
            System.String requestConfiguration_configuration_Edi_configuration_Edi_OutputLocation_outputLocation_Key = null;
            if (cmdletContext.OutputLocation_Key != null)
            {
                requestConfiguration_configuration_Edi_configuration_Edi_OutputLocation_outputLocation_Key = cmdletContext.OutputLocation_Key;
            }
            if (requestConfiguration_configuration_Edi_configuration_Edi_OutputLocation_outputLocation_Key != null)
            {
                requestConfiguration_configuration_Edi_configuration_Edi_OutputLocation.Key = requestConfiguration_configuration_Edi_configuration_Edi_OutputLocation_outputLocation_Key;
                requestConfiguration_configuration_Edi_configuration_Edi_OutputLocationIsNull = false;
            }
             // determine if requestConfiguration_configuration_Edi_configuration_Edi_OutputLocation should be set to null
            if (requestConfiguration_configuration_Edi_configuration_Edi_OutputLocationIsNull)
            {
                requestConfiguration_configuration_Edi_configuration_Edi_OutputLocation = null;
            }
            if (requestConfiguration_configuration_Edi_configuration_Edi_OutputLocation != null)
            {
                requestConfiguration_configuration_Edi.OutputLocation = requestConfiguration_configuration_Edi_configuration_Edi_OutputLocation;
                requestConfiguration_configuration_EdiIsNull = false;
            }
             // determine if requestConfiguration_configuration_Edi should be set to null
            if (requestConfiguration_configuration_EdiIsNull)
            {
                requestConfiguration_configuration_Edi = null;
            }
            if (requestConfiguration_configuration_Edi != null)
            {
                request.Configuration.Edi = requestConfiguration_configuration_Edi;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.InstructionsDocument != null)
            {
                request.InstructionsDocuments = cmdletContext.InstructionsDocument;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.B2bi.Model.UpdateCapabilityResponse CallAWSServiceOperation(IAmazonB2bi client, Amazon.B2bi.Model.UpdateCapabilityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS B2B Data Interchange", "UpdateCapability");
            try
            {
                return client.UpdateCapabilityAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CapabilityId { get; set; }
            public Amazon.B2bi.CapabilityDirection Edi_CapabilityDirection { get; set; }
            public System.String InputLocation_BucketName { get; set; }
            public System.String InputLocation_Key { get; set; }
            public System.String OutputLocation_BucketName { get; set; }
            public System.String OutputLocation_Key { get; set; }
            public System.String Edi_TransformerId { get; set; }
            public Amazon.B2bi.X12TransactionSet X12Details_TransactionSet { get; set; }
            public Amazon.B2bi.X12Version X12Details_Version { get; set; }
            public List<Amazon.B2bi.Model.S3Location> InstructionsDocument { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.B2bi.Model.UpdateCapabilityResponse, UpdateB2BICapabilityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

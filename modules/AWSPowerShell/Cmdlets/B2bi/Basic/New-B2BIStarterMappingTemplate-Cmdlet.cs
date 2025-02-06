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
using Amazon.B2bi;
using Amazon.B2bi.Model;

namespace Amazon.PowerShell.Cmdlets.B2BI
{
    /// <summary>
    /// Amazon Web Services B2B Data Interchange uses a mapping template in JSONata or XSLT
    /// format to transform a customer input file into a JSON or XML file that can be converted
    /// to EDI.
    /// 
    ///  
    /// <para>
    /// If you provide a sample EDI file with the same structure as the EDI files that you
    /// wish to generate, then the service can generate a mapping template. The starter template
    /// contains placeholder values which you can replace with JSONata or XSLT expressions
    /// to take data from your input file and insert it into the JSON or XML file that is
    /// used to generate the EDI.
    /// </para><para>
    /// If you do not provide a sample EDI file, then the service can generate a mapping template
    /// based on the EDI settings in the <c>templateDetails</c> parameter. 
    /// </para><para>
    ///  Currently, we only support generating a template that can generate the input to produce
    /// an Outbound X12 EDI file.
    /// </para>
    /// </summary>
    [Cmdlet("New", "B2BIStarterMappingTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS B2B Data Interchange CreateStarterMappingTemplate API operation.", Operation = new[] {"CreateStarterMappingTemplate"}, SelectReturnType = typeof(Amazon.B2bi.Model.CreateStarterMappingTemplateResponse))]
    [AWSCmdletOutput("System.String or Amazon.B2bi.Model.CreateStarterMappingTemplateResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.B2bi.Model.CreateStarterMappingTemplateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewB2BIStarterMappingTemplateCmdlet : AmazonB2biClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OutputSampleLocation_BucketName
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputSampleLocation_BucketName { get; set; }
        #endregion
        
        #region Parameter OutputSampleLocation_Key
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon S3 key for the file location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputSampleLocation_Key { get; set; }
        #endregion
        
        #region Parameter MappingType
        /// <summary>
        /// <para>
        /// <para>Specify the format for the mapping template: either JSONATA or XSLT.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.B2bi.MappingType")]
        public Amazon.B2bi.MappingType MappingType { get; set; }
        #endregion
        
        #region Parameter X12_TransactionSet
        /// <summary>
        /// <para>
        /// <para>Returns an enumerated type where each value identifies an X12 transaction set. Transaction
        /// sets are maintained by the X12 Accredited Standards Committee.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TemplateDetails_X12_TransactionSet")]
        [AWSConstantClassSource("Amazon.B2bi.X12TransactionSet")]
        public Amazon.B2bi.X12TransactionSet X12_TransactionSet { get; set; }
        #endregion
        
        #region Parameter X12_Version
        /// <summary>
        /// <para>
        /// <para>Returns the version to use for the specified X12 transaction set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TemplateDetails_X12_Version")]
        [AWSConstantClassSource("Amazon.B2bi.X12Version")]
        public Amazon.B2bi.X12Version X12_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MappingTemplate'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.B2bi.Model.CreateStarterMappingTemplateResponse).
        /// Specifying the name of a property of type Amazon.B2bi.Model.CreateStarterMappingTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MappingTemplate";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MappingType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MappingType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MappingType' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OutputSampleLocation_BucketName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-B2BIStarterMappingTemplate (CreateStarterMappingTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.B2bi.Model.CreateStarterMappingTemplateResponse, NewB2BIStarterMappingTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MappingType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MappingType = this.MappingType;
            #if MODULAR
            if (this.MappingType == null && ParameterWasBound(nameof(this.MappingType)))
            {
                WriteWarning("You are passing $null as a value for parameter MappingType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputSampleLocation_BucketName = this.OutputSampleLocation_BucketName;
            context.OutputSampleLocation_Key = this.OutputSampleLocation_Key;
            context.X12_TransactionSet = this.X12_TransactionSet;
            context.X12_Version = this.X12_Version;
            
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
            var request = new Amazon.B2bi.Model.CreateStarterMappingTemplateRequest();
            
            if (cmdletContext.MappingType != null)
            {
                request.MappingType = cmdletContext.MappingType;
            }
            
             // populate OutputSampleLocation
            var requestOutputSampleLocationIsNull = true;
            request.OutputSampleLocation = new Amazon.B2bi.Model.S3Location();
            System.String requestOutputSampleLocation_outputSampleLocation_BucketName = null;
            if (cmdletContext.OutputSampleLocation_BucketName != null)
            {
                requestOutputSampleLocation_outputSampleLocation_BucketName = cmdletContext.OutputSampleLocation_BucketName;
            }
            if (requestOutputSampleLocation_outputSampleLocation_BucketName != null)
            {
                request.OutputSampleLocation.BucketName = requestOutputSampleLocation_outputSampleLocation_BucketName;
                requestOutputSampleLocationIsNull = false;
            }
            System.String requestOutputSampleLocation_outputSampleLocation_Key = null;
            if (cmdletContext.OutputSampleLocation_Key != null)
            {
                requestOutputSampleLocation_outputSampleLocation_Key = cmdletContext.OutputSampleLocation_Key;
            }
            if (requestOutputSampleLocation_outputSampleLocation_Key != null)
            {
                request.OutputSampleLocation.Key = requestOutputSampleLocation_outputSampleLocation_Key;
                requestOutputSampleLocationIsNull = false;
            }
             // determine if request.OutputSampleLocation should be set to null
            if (requestOutputSampleLocationIsNull)
            {
                request.OutputSampleLocation = null;
            }
            
             // populate TemplateDetails
            var requestTemplateDetailsIsNull = true;
            request.TemplateDetails = new Amazon.B2bi.Model.TemplateDetails();
            Amazon.B2bi.Model.X12Details requestTemplateDetails_templateDetails_X12 = null;
            
             // populate X12
            var requestTemplateDetails_templateDetails_X12IsNull = true;
            requestTemplateDetails_templateDetails_X12 = new Amazon.B2bi.Model.X12Details();
            Amazon.B2bi.X12TransactionSet requestTemplateDetails_templateDetails_X12_x12_TransactionSet = null;
            if (cmdletContext.X12_TransactionSet != null)
            {
                requestTemplateDetails_templateDetails_X12_x12_TransactionSet = cmdletContext.X12_TransactionSet;
            }
            if (requestTemplateDetails_templateDetails_X12_x12_TransactionSet != null)
            {
                requestTemplateDetails_templateDetails_X12.TransactionSet = requestTemplateDetails_templateDetails_X12_x12_TransactionSet;
                requestTemplateDetails_templateDetails_X12IsNull = false;
            }
            Amazon.B2bi.X12Version requestTemplateDetails_templateDetails_X12_x12_Version = null;
            if (cmdletContext.X12_Version != null)
            {
                requestTemplateDetails_templateDetails_X12_x12_Version = cmdletContext.X12_Version;
            }
            if (requestTemplateDetails_templateDetails_X12_x12_Version != null)
            {
                requestTemplateDetails_templateDetails_X12.Version = requestTemplateDetails_templateDetails_X12_x12_Version;
                requestTemplateDetails_templateDetails_X12IsNull = false;
            }
             // determine if requestTemplateDetails_templateDetails_X12 should be set to null
            if (requestTemplateDetails_templateDetails_X12IsNull)
            {
                requestTemplateDetails_templateDetails_X12 = null;
            }
            if (requestTemplateDetails_templateDetails_X12 != null)
            {
                request.TemplateDetails.X12 = requestTemplateDetails_templateDetails_X12;
                requestTemplateDetailsIsNull = false;
            }
             // determine if request.TemplateDetails should be set to null
            if (requestTemplateDetailsIsNull)
            {
                request.TemplateDetails = null;
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
        
        private Amazon.B2bi.Model.CreateStarterMappingTemplateResponse CallAWSServiceOperation(IAmazonB2bi client, Amazon.B2bi.Model.CreateStarterMappingTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS B2B Data Interchange", "CreateStarterMappingTemplate");
            try
            {
                #if DESKTOP
                return client.CreateStarterMappingTemplate(request);
                #elif CORECLR
                return client.CreateStarterMappingTemplateAsync(request).GetAwaiter().GetResult();
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
            public Amazon.B2bi.MappingType MappingType { get; set; }
            public System.String OutputSampleLocation_BucketName { get; set; }
            public System.String OutputSampleLocation_Key { get; set; }
            public Amazon.B2bi.X12TransactionSet X12_TransactionSet { get; set; }
            public Amazon.B2bi.X12Version X12_Version { get; set; }
            public System.Func<Amazon.B2bi.Model.CreateStarterMappingTemplateResponse, NewB2BIStarterMappingTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MappingTemplate;
        }
        
    }
}

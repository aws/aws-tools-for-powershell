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
using Amazon.B2bi;
using Amazon.B2bi.Model;

namespace Amazon.PowerShell.Cmdlets.B2BI
{
    /// <summary>
    /// Maps the input file according to the provided template file. The API call downloads
    /// the file contents from the Amazon S3 location, and passes the contents in as a string,
    /// to the <c>inputFileContent</c> parameter.
    /// </summary>
    [Cmdlet("Test", "B2BIMapping")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS B2B Data Interchange TestMapping API operation.", Operation = new[] {"TestMapping"}, SelectReturnType = typeof(Amazon.B2bi.Model.TestMappingResponse))]
    [AWSCmdletOutput("System.String or Amazon.B2bi.Model.TestMappingResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.B2bi.Model.TestMappingResponse) can be returned by specifying '-Select *'."
    )]
    public partial class TestB2BIMappingCmdlet : AmazonB2biClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FileFormat
        /// <summary>
        /// <para>
        /// <para>Specifies that the currently supported file formats for EDI transformations are <c>JSON</c>
        /// and <c>XML</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.B2bi.FileFormat")]
        public Amazon.B2bi.FileFormat FileFormat { get; set; }
        #endregion
        
        #region Parameter InputFileContent
        /// <summary>
        /// <para>
        /// <para>Specify the contents of the EDI (electronic data interchange) XML or JSON file that
        /// is used as input for the transform.</para>
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
        public System.String InputFileContent { get; set; }
        #endregion
        
        #region Parameter MappingTemplate
        /// <summary>
        /// <para>
        /// <para>Specifies the mapping template for the transformer. This template is used to map the
        /// parsed EDI file using JSONata or XSLT.</para><note><para>This parameter is available for backwards compatibility. Use the <a href="https://docs.aws.amazon.com/b2bi/latest/APIReference/API_Mapping.html">Mapping</a>
        /// data type instead.</para></note>
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
        public System.String MappingTemplate { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MappedFileContent'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.B2bi.Model.TestMappingResponse).
        /// Specifying the name of a property of type Amazon.B2bi.Model.TestMappingResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MappedFileContent";
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
                context.Select = CreateSelectDelegate<Amazon.B2bi.Model.TestMappingResponse, TestB2BIMappingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FileFormat = this.FileFormat;
            #if MODULAR
            if (this.FileFormat == null && ParameterWasBound(nameof(this.FileFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter FileFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputFileContent = this.InputFileContent;
            #if MODULAR
            if (this.InputFileContent == null && ParameterWasBound(nameof(this.InputFileContent)))
            {
                WriteWarning("You are passing $null as a value for parameter InputFileContent which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MappingTemplate = this.MappingTemplate;
            #if MODULAR
            if (this.MappingTemplate == null && ParameterWasBound(nameof(this.MappingTemplate)))
            {
                WriteWarning("You are passing $null as a value for parameter MappingTemplate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.B2bi.Model.TestMappingRequest();
            
            if (cmdletContext.FileFormat != null)
            {
                request.FileFormat = cmdletContext.FileFormat;
            }
            if (cmdletContext.InputFileContent != null)
            {
                request.InputFileContent = cmdletContext.InputFileContent;
            }
            if (cmdletContext.MappingTemplate != null)
            {
                request.MappingTemplate = cmdletContext.MappingTemplate;
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
        
        private Amazon.B2bi.Model.TestMappingResponse CallAWSServiceOperation(IAmazonB2bi client, Amazon.B2bi.Model.TestMappingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS B2B Data Interchange", "TestMapping");
            try
            {
                #if DESKTOP
                return client.TestMapping(request);
                #elif CORECLR
                return client.TestMappingAsync(request).GetAwaiter().GetResult();
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
            public Amazon.B2bi.FileFormat FileFormat { get; set; }
            public System.String InputFileContent { get; set; }
            public System.String MappingTemplate { get; set; }
            public System.Func<Amazon.B2bi.Model.TestMappingResponse, TestB2BIMappingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MappedFileContent;
        }
        
    }
}

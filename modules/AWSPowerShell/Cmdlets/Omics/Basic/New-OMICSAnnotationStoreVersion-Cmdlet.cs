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
using Amazon.Omics;
using Amazon.Omics.Model;

namespace Amazon.PowerShell.Cmdlets.OMICS
{
    /// <summary>
    /// Creates a new version of an annotation store.
    /// </summary>
    [Cmdlet("New", "OMICSAnnotationStoreVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Omics.Model.CreateAnnotationStoreVersionResponse")]
    [AWSCmdlet("Calls the Amazon Omics CreateAnnotationStoreVersion API operation.", Operation = new[] {"CreateAnnotationStoreVersion"}, SelectReturnType = typeof(Amazon.Omics.Model.CreateAnnotationStoreVersionResponse))]
    [AWSCmdletOutput("Amazon.Omics.Model.CreateAnnotationStoreVersionResponse",
        "This cmdlet returns an Amazon.Omics.Model.CreateAnnotationStoreVersionResponse object containing multiple properties."
    )]
    public partial class NewOMICSAnnotationStoreVersionCmdlet : AmazonOmicsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TsvVersionOptions_AnnotationType
        /// <summary>
        /// <para>
        /// <para> The store version's annotation type. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VersionOptions_TsvVersionOptions_AnnotationType")]
        [AWSConstantClassSource("Amazon.Omics.AnnotationType")]
        public Amazon.Omics.AnnotationType TsvVersionOptions_AnnotationType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> The description of an annotation store version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter TsvVersionOptions_FormatToHeader
        /// <summary>
        /// <para>
        /// <para> The annotation store version's header key to column name mapping. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VersionOptions_TsvVersionOptions_FormatToHeader")]
        public System.Collections.Hashtable TsvVersionOptions_FormatToHeader { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para> The name of an annotation store version from which versions are being created. </para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter TsvVersionOptions_Schema
        /// <summary>
        /// <para>
        /// <para> The TSV schema for an annotation store version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VersionOptions_TsvVersionOptions_Schema")]
        public System.Collections.Hashtable[] TsvVersionOptions_Schema { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> Any tags added to annotation store version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter VersionName
        /// <summary>
        /// <para>
        /// <para> The name given to an annotation store version to distinguish it from other versions.
        /// </para>
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
        public System.String VersionName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Omics.Model.CreateAnnotationStoreVersionResponse).
        /// Specifying the name of a property of type Amazon.Omics.Model.CreateAnnotationStoreVersionResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OMICSAnnotationStoreVersion (CreateAnnotationStoreVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Omics.Model.CreateAnnotationStoreVersionResponse, NewOMICSAnnotationStoreVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.VersionName = this.VersionName;
            #if MODULAR
            if (this.VersionName == null && ParameterWasBound(nameof(this.VersionName)))
            {
                WriteWarning("You are passing $null as a value for parameter VersionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TsvVersionOptions_AnnotationType = this.TsvVersionOptions_AnnotationType;
            if (this.TsvVersionOptions_FormatToHeader != null)
            {
                context.TsvVersionOptions_FormatToHeader = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.TsvVersionOptions_FormatToHeader.Keys)
                {
                    context.TsvVersionOptions_FormatToHeader.Add((String)hashKey, (System.String)(this.TsvVersionOptions_FormatToHeader[hashKey]));
                }
            }
            if (this.TsvVersionOptions_Schema != null)
            {
                context.TsvVersionOptions_Schema = new List<Dictionary<System.String, System.String>>();
                foreach (var hashTable in this.TsvVersionOptions_Schema)
                {
                    var d = new Dictionary<System.String, System.String>();
                    foreach (var hashKey in hashTable.Keys)
                    {
                        d.Add((String)hashKey, (String)(hashTable[hashKey]));
                    }
                    context.TsvVersionOptions_Schema.Add(d);
                }
            }
            
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
            var request = new Amazon.Omics.Model.CreateAnnotationStoreVersionRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VersionName != null)
            {
                request.VersionName = cmdletContext.VersionName;
            }
            
             // populate VersionOptions
            var requestVersionOptionsIsNull = true;
            request.VersionOptions = new Amazon.Omics.Model.VersionOptions();
            Amazon.Omics.Model.TsvVersionOptions requestVersionOptions_versionOptions_TsvVersionOptions = null;
            
             // populate TsvVersionOptions
            var requestVersionOptions_versionOptions_TsvVersionOptionsIsNull = true;
            requestVersionOptions_versionOptions_TsvVersionOptions = new Amazon.Omics.Model.TsvVersionOptions();
            Amazon.Omics.AnnotationType requestVersionOptions_versionOptions_TsvVersionOptions_tsvVersionOptions_AnnotationType = null;
            if (cmdletContext.TsvVersionOptions_AnnotationType != null)
            {
                requestVersionOptions_versionOptions_TsvVersionOptions_tsvVersionOptions_AnnotationType = cmdletContext.TsvVersionOptions_AnnotationType;
            }
            if (requestVersionOptions_versionOptions_TsvVersionOptions_tsvVersionOptions_AnnotationType != null)
            {
                requestVersionOptions_versionOptions_TsvVersionOptions.AnnotationType = requestVersionOptions_versionOptions_TsvVersionOptions_tsvVersionOptions_AnnotationType;
                requestVersionOptions_versionOptions_TsvVersionOptionsIsNull = false;
            }
            Dictionary<System.String, System.String> requestVersionOptions_versionOptions_TsvVersionOptions_tsvVersionOptions_FormatToHeader = null;
            if (cmdletContext.TsvVersionOptions_FormatToHeader != null)
            {
                requestVersionOptions_versionOptions_TsvVersionOptions_tsvVersionOptions_FormatToHeader = cmdletContext.TsvVersionOptions_FormatToHeader;
            }
            if (requestVersionOptions_versionOptions_TsvVersionOptions_tsvVersionOptions_FormatToHeader != null)
            {
                requestVersionOptions_versionOptions_TsvVersionOptions.FormatToHeader = requestVersionOptions_versionOptions_TsvVersionOptions_tsvVersionOptions_FormatToHeader;
                requestVersionOptions_versionOptions_TsvVersionOptionsIsNull = false;
            }
            List<Dictionary<System.String, System.String>> requestVersionOptions_versionOptions_TsvVersionOptions_tsvVersionOptions_Schema = null;
            if (cmdletContext.TsvVersionOptions_Schema != null)
            {
                requestVersionOptions_versionOptions_TsvVersionOptions_tsvVersionOptions_Schema = cmdletContext.TsvVersionOptions_Schema;
            }
            if (requestVersionOptions_versionOptions_TsvVersionOptions_tsvVersionOptions_Schema != null)
            {
                requestVersionOptions_versionOptions_TsvVersionOptions.Schema = requestVersionOptions_versionOptions_TsvVersionOptions_tsvVersionOptions_Schema;
                requestVersionOptions_versionOptions_TsvVersionOptionsIsNull = false;
            }
             // determine if requestVersionOptions_versionOptions_TsvVersionOptions should be set to null
            if (requestVersionOptions_versionOptions_TsvVersionOptionsIsNull)
            {
                requestVersionOptions_versionOptions_TsvVersionOptions = null;
            }
            if (requestVersionOptions_versionOptions_TsvVersionOptions != null)
            {
                request.VersionOptions.TsvVersionOptions = requestVersionOptions_versionOptions_TsvVersionOptions;
                requestVersionOptionsIsNull = false;
            }
             // determine if request.VersionOptions should be set to null
            if (requestVersionOptionsIsNull)
            {
                request.VersionOptions = null;
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
        
        private Amazon.Omics.Model.CreateAnnotationStoreVersionResponse CallAWSServiceOperation(IAmazonOmics client, Amazon.Omics.Model.CreateAnnotationStoreVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Omics", "CreateAnnotationStoreVersion");
            try
            {
                #if DESKTOP
                return client.CreateAnnotationStoreVersion(request);
                #elif CORECLR
                return client.CreateAnnotationStoreVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String VersionName { get; set; }
            public Amazon.Omics.AnnotationType TsvVersionOptions_AnnotationType { get; set; }
            public Dictionary<System.String, System.String> TsvVersionOptions_FormatToHeader { get; set; }
            public List<Dictionary<System.String, System.String>> TsvVersionOptions_Schema { get; set; }
            public System.Func<Amazon.Omics.Model.CreateAnnotationStoreVersionResponse, NewOMICSAnnotationStoreVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

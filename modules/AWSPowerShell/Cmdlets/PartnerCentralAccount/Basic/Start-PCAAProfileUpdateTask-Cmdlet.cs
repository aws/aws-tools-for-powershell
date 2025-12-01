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
using Amazon.PartnerCentralAccount;
using Amazon.PartnerCentralAccount.Model;

namespace Amazon.PowerShell.Cmdlets.PCAA
{
    /// <summary>
    /// Initiates a profile update task to modify partner profile information asynchronously.
    /// </summary>
    [Cmdlet("Start", "PCAAProfileUpdateTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PartnerCentralAccount.Model.StartProfileUpdateTaskResponse")]
    [AWSCmdlet("Calls the Partner Central Account API StartProfileUpdateTask API operation.", Operation = new[] {"StartProfileUpdateTask"}, SelectReturnType = typeof(Amazon.PartnerCentralAccount.Model.StartProfileUpdateTaskResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralAccount.Model.StartProfileUpdateTaskResponse",
        "This cmdlet returns an Amazon.PartnerCentralAccount.Model.StartProfileUpdateTaskResponse object containing multiple properties."
    )]
    public partial class StartPCAAProfileUpdateTaskCmdlet : AmazonPartnerCentralAccountClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>The catalog identifier for the partner account.</para>
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
        public System.String Catalog { get; set; }
        #endregion
        
        #region Parameter TaskDetails_Description
        /// <summary>
        /// <para>
        /// <para>The updated description for the partner profile.</para>
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
        public System.String TaskDetails_Description { get; set; }
        #endregion
        
        #region Parameter TaskDetails_DisplayName
        /// <summary>
        /// <para>
        /// <para>The updated display name for the partner profile.</para>
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
        public System.String TaskDetails_DisplayName { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the partner account.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter TaskDetails_IndustrySegment
        /// <summary>
        /// <para>
        /// <para>The updated industry segments for the partner profile.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("TaskDetails_IndustrySegments")]
        public System.String[] TaskDetails_IndustrySegment { get; set; }
        #endregion
        
        #region Parameter TaskDetails_LocalizedContent
        /// <summary>
        /// <para>
        /// <para>The updated localized content for the partner profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TaskDetails_LocalizedContents")]
        public Amazon.PartnerCentralAccount.Model.LocalizedContent[] TaskDetails_LocalizedContent { get; set; }
        #endregion
        
        #region Parameter TaskDetails_LogoUrl
        /// <summary>
        /// <para>
        /// <para>The updated logo URL for the partner profile.</para>
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
        public System.String TaskDetails_LogoUrl { get; set; }
        #endregion
        
        #region Parameter TaskDetails_PrimarySolutionType
        /// <summary>
        /// <para>
        /// <para>The updated primary solution type for the partner profile.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PartnerCentralAccount.PrimarySolutionType")]
        public Amazon.PartnerCentralAccount.PrimarySolutionType TaskDetails_PrimarySolutionType { get; set; }
        #endregion
        
        #region Parameter TaskDetails_TranslationSourceLocale
        /// <summary>
        /// <para>
        /// <para>The updated translation source locale for the partner profile.</para>
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
        public System.String TaskDetails_TranslationSourceLocale { get; set; }
        #endregion
        
        #region Parameter TaskDetails_WebsiteUrl
        /// <summary>
        /// <para>
        /// <para>The updated website URL for the partner profile.</para>
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
        public System.String TaskDetails_WebsiteUrl { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralAccount.Model.StartProfileUpdateTaskResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralAccount.Model.StartProfileUpdateTaskResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-PCAAProfileUpdateTask (StartProfileUpdateTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralAccount.Model.StartProfileUpdateTaskResponse, StartPCAAProfileUpdateTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TaskDetails_Description = this.TaskDetails_Description;
            #if MODULAR
            if (this.TaskDetails_Description == null && ParameterWasBound(nameof(this.TaskDetails_Description)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskDetails_Description which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TaskDetails_DisplayName = this.TaskDetails_DisplayName;
            #if MODULAR
            if (this.TaskDetails_DisplayName == null && ParameterWasBound(nameof(this.TaskDetails_DisplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskDetails_DisplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TaskDetails_IndustrySegment != null)
            {
                context.TaskDetails_IndustrySegment = new List<System.String>(this.TaskDetails_IndustrySegment);
            }
            #if MODULAR
            if (this.TaskDetails_IndustrySegment == null && ParameterWasBound(nameof(this.TaskDetails_IndustrySegment)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskDetails_IndustrySegment which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TaskDetails_LocalizedContent != null)
            {
                context.TaskDetails_LocalizedContent = new List<Amazon.PartnerCentralAccount.Model.LocalizedContent>(this.TaskDetails_LocalizedContent);
            }
            context.TaskDetails_LogoUrl = this.TaskDetails_LogoUrl;
            #if MODULAR
            if (this.TaskDetails_LogoUrl == null && ParameterWasBound(nameof(this.TaskDetails_LogoUrl)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskDetails_LogoUrl which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TaskDetails_PrimarySolutionType = this.TaskDetails_PrimarySolutionType;
            #if MODULAR
            if (this.TaskDetails_PrimarySolutionType == null && ParameterWasBound(nameof(this.TaskDetails_PrimarySolutionType)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskDetails_PrimarySolutionType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TaskDetails_TranslationSourceLocale = this.TaskDetails_TranslationSourceLocale;
            #if MODULAR
            if (this.TaskDetails_TranslationSourceLocale == null && ParameterWasBound(nameof(this.TaskDetails_TranslationSourceLocale)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskDetails_TranslationSourceLocale which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TaskDetails_WebsiteUrl = this.TaskDetails_WebsiteUrl;
            #if MODULAR
            if (this.TaskDetails_WebsiteUrl == null && ParameterWasBound(nameof(this.TaskDetails_WebsiteUrl)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskDetails_WebsiteUrl which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PartnerCentralAccount.Model.StartProfileUpdateTaskRequest();
            
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            
             // populate TaskDetails
            var requestTaskDetailsIsNull = true;
            request.TaskDetails = new Amazon.PartnerCentralAccount.Model.TaskDetails();
            System.String requestTaskDetails_taskDetails_Description = null;
            if (cmdletContext.TaskDetails_Description != null)
            {
                requestTaskDetails_taskDetails_Description = cmdletContext.TaskDetails_Description;
            }
            if (requestTaskDetails_taskDetails_Description != null)
            {
                request.TaskDetails.Description = requestTaskDetails_taskDetails_Description;
                requestTaskDetailsIsNull = false;
            }
            System.String requestTaskDetails_taskDetails_DisplayName = null;
            if (cmdletContext.TaskDetails_DisplayName != null)
            {
                requestTaskDetails_taskDetails_DisplayName = cmdletContext.TaskDetails_DisplayName;
            }
            if (requestTaskDetails_taskDetails_DisplayName != null)
            {
                request.TaskDetails.DisplayName = requestTaskDetails_taskDetails_DisplayName;
                requestTaskDetailsIsNull = false;
            }
            List<System.String> requestTaskDetails_taskDetails_IndustrySegment = null;
            if (cmdletContext.TaskDetails_IndustrySegment != null)
            {
                requestTaskDetails_taskDetails_IndustrySegment = cmdletContext.TaskDetails_IndustrySegment;
            }
            if (requestTaskDetails_taskDetails_IndustrySegment != null)
            {
                request.TaskDetails.IndustrySegments = requestTaskDetails_taskDetails_IndustrySegment;
                requestTaskDetailsIsNull = false;
            }
            List<Amazon.PartnerCentralAccount.Model.LocalizedContent> requestTaskDetails_taskDetails_LocalizedContent = null;
            if (cmdletContext.TaskDetails_LocalizedContent != null)
            {
                requestTaskDetails_taskDetails_LocalizedContent = cmdletContext.TaskDetails_LocalizedContent;
            }
            if (requestTaskDetails_taskDetails_LocalizedContent != null)
            {
                request.TaskDetails.LocalizedContents = requestTaskDetails_taskDetails_LocalizedContent;
                requestTaskDetailsIsNull = false;
            }
            System.String requestTaskDetails_taskDetails_LogoUrl = null;
            if (cmdletContext.TaskDetails_LogoUrl != null)
            {
                requestTaskDetails_taskDetails_LogoUrl = cmdletContext.TaskDetails_LogoUrl;
            }
            if (requestTaskDetails_taskDetails_LogoUrl != null)
            {
                request.TaskDetails.LogoUrl = requestTaskDetails_taskDetails_LogoUrl;
                requestTaskDetailsIsNull = false;
            }
            Amazon.PartnerCentralAccount.PrimarySolutionType requestTaskDetails_taskDetails_PrimarySolutionType = null;
            if (cmdletContext.TaskDetails_PrimarySolutionType != null)
            {
                requestTaskDetails_taskDetails_PrimarySolutionType = cmdletContext.TaskDetails_PrimarySolutionType;
            }
            if (requestTaskDetails_taskDetails_PrimarySolutionType != null)
            {
                request.TaskDetails.PrimarySolutionType = requestTaskDetails_taskDetails_PrimarySolutionType;
                requestTaskDetailsIsNull = false;
            }
            System.String requestTaskDetails_taskDetails_TranslationSourceLocale = null;
            if (cmdletContext.TaskDetails_TranslationSourceLocale != null)
            {
                requestTaskDetails_taskDetails_TranslationSourceLocale = cmdletContext.TaskDetails_TranslationSourceLocale;
            }
            if (requestTaskDetails_taskDetails_TranslationSourceLocale != null)
            {
                request.TaskDetails.TranslationSourceLocale = requestTaskDetails_taskDetails_TranslationSourceLocale;
                requestTaskDetailsIsNull = false;
            }
            System.String requestTaskDetails_taskDetails_WebsiteUrl = null;
            if (cmdletContext.TaskDetails_WebsiteUrl != null)
            {
                requestTaskDetails_taskDetails_WebsiteUrl = cmdletContext.TaskDetails_WebsiteUrl;
            }
            if (requestTaskDetails_taskDetails_WebsiteUrl != null)
            {
                request.TaskDetails.WebsiteUrl = requestTaskDetails_taskDetails_WebsiteUrl;
                requestTaskDetailsIsNull = false;
            }
             // determine if request.TaskDetails should be set to null
            if (requestTaskDetailsIsNull)
            {
                request.TaskDetails = null;
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
        
        private Amazon.PartnerCentralAccount.Model.StartProfileUpdateTaskResponse CallAWSServiceOperation(IAmazonPartnerCentralAccount client, Amazon.PartnerCentralAccount.Model.StartProfileUpdateTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Account API", "StartProfileUpdateTask");
            try
            {
                #if DESKTOP
                return client.StartProfileUpdateTask(request);
                #elif CORECLR
                return client.StartProfileUpdateTaskAsync(request).GetAwaiter().GetResult();
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
            public System.String Catalog { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Identifier { get; set; }
            public System.String TaskDetails_Description { get; set; }
            public System.String TaskDetails_DisplayName { get; set; }
            public List<System.String> TaskDetails_IndustrySegment { get; set; }
            public List<Amazon.PartnerCentralAccount.Model.LocalizedContent> TaskDetails_LocalizedContent { get; set; }
            public System.String TaskDetails_LogoUrl { get; set; }
            public Amazon.PartnerCentralAccount.PrimarySolutionType TaskDetails_PrimarySolutionType { get; set; }
            public System.String TaskDetails_TranslationSourceLocale { get; set; }
            public System.String TaskDetails_WebsiteUrl { get; set; }
            public System.Func<Amazon.PartnerCentralAccount.Model.StartProfileUpdateTaskResponse, StartPCAAProfileUpdateTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

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
using Amazon.ConnectCases;
using Amazon.ConnectCases.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CCAS
{
    /// <summary>
    /// Creates a layout in the Cases domain. Layouts define the following configuration in
    /// the top section and More Info tab of the Cases user interface:
    /// 
    ///  <ul><li><para>
    /// Fields to display to the users
    /// </para></li><li><para>
    /// Field ordering
    /// </para></li></ul><note><para>
    /// Title and Status fields cannot be part of layouts since they are not configurable.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "CCASLayout", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConnectCases.Model.CreateLayoutResponse")]
    [AWSCmdlet("Calls the Amazon Connect Cases CreateLayout API operation.", Operation = new[] {"CreateLayout"}, SelectReturnType = typeof(Amazon.ConnectCases.Model.CreateLayoutResponse))]
    [AWSCmdletOutput("Amazon.ConnectCases.Model.CreateLayoutResponse",
        "This cmdlet returns an Amazon.ConnectCases.Model.CreateLayoutResponse object containing multiple properties."
    )]
    public partial class NewCCASLayoutCmdlet : AmazonConnectCasesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DomainId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Cases domain. </para>
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
        public System.String DomainId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the layout. It must be unique for the Cases domain.</para>
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
        
        #region Parameter MoreInfo_Section
        /// <summary>
        /// <para>
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Basic_MoreInfo_Sections")]
        public Amazon.ConnectCases.Model.Section[] MoreInfo_Section { get; set; }
        #endregion
        
        #region Parameter TopPanel_Section
        /// <summary>
        /// <para>
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Basic_TopPanel_Sections")]
        public Amazon.ConnectCases.Model.Section[] TopPanel_Section { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectCases.Model.CreateLayoutResponse).
        /// Specifying the name of a property of type Amazon.ConnectCases.Model.CreateLayoutResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CCASLayout (CreateLayout)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectCases.Model.CreateLayoutResponse, NewCCASLayoutCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.MoreInfo_Section != null)
            {
                context.MoreInfo_Section = new List<Amazon.ConnectCases.Model.Section>(this.MoreInfo_Section);
            }
            if (this.TopPanel_Section != null)
            {
                context.TopPanel_Section = new List<Amazon.ConnectCases.Model.Section>(this.TopPanel_Section);
            }
            context.DomainId = this.DomainId;
            #if MODULAR
            if (this.DomainId == null && ParameterWasBound(nameof(this.DomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConnectCases.Model.CreateLayoutRequest();
            
            
             // populate Content
            var requestContentIsNull = true;
            request.Content = new Amazon.ConnectCases.Model.LayoutContent();
            Amazon.ConnectCases.Model.BasicLayout requestContent_content_Basic = null;
            
             // populate Basic
            var requestContent_content_BasicIsNull = true;
            requestContent_content_Basic = new Amazon.ConnectCases.Model.BasicLayout();
            Amazon.ConnectCases.Model.LayoutSections requestContent_content_Basic_content_Basic_MoreInfo = null;
            
             // populate MoreInfo
            var requestContent_content_Basic_content_Basic_MoreInfoIsNull = true;
            requestContent_content_Basic_content_Basic_MoreInfo = new Amazon.ConnectCases.Model.LayoutSections();
            List<Amazon.ConnectCases.Model.Section> requestContent_content_Basic_content_Basic_MoreInfo_moreInfo_Section = null;
            if (cmdletContext.MoreInfo_Section != null)
            {
                requestContent_content_Basic_content_Basic_MoreInfo_moreInfo_Section = cmdletContext.MoreInfo_Section;
            }
            if (requestContent_content_Basic_content_Basic_MoreInfo_moreInfo_Section != null)
            {
                requestContent_content_Basic_content_Basic_MoreInfo.Sections = requestContent_content_Basic_content_Basic_MoreInfo_moreInfo_Section;
                requestContent_content_Basic_content_Basic_MoreInfoIsNull = false;
            }
             // determine if requestContent_content_Basic_content_Basic_MoreInfo should be set to null
            if (requestContent_content_Basic_content_Basic_MoreInfoIsNull)
            {
                requestContent_content_Basic_content_Basic_MoreInfo = null;
            }
            if (requestContent_content_Basic_content_Basic_MoreInfo != null)
            {
                requestContent_content_Basic.MoreInfo = requestContent_content_Basic_content_Basic_MoreInfo;
                requestContent_content_BasicIsNull = false;
            }
            Amazon.ConnectCases.Model.LayoutSections requestContent_content_Basic_content_Basic_TopPanel = null;
            
             // populate TopPanel
            var requestContent_content_Basic_content_Basic_TopPanelIsNull = true;
            requestContent_content_Basic_content_Basic_TopPanel = new Amazon.ConnectCases.Model.LayoutSections();
            List<Amazon.ConnectCases.Model.Section> requestContent_content_Basic_content_Basic_TopPanel_topPanel_Section = null;
            if (cmdletContext.TopPanel_Section != null)
            {
                requestContent_content_Basic_content_Basic_TopPanel_topPanel_Section = cmdletContext.TopPanel_Section;
            }
            if (requestContent_content_Basic_content_Basic_TopPanel_topPanel_Section != null)
            {
                requestContent_content_Basic_content_Basic_TopPanel.Sections = requestContent_content_Basic_content_Basic_TopPanel_topPanel_Section;
                requestContent_content_Basic_content_Basic_TopPanelIsNull = false;
            }
             // determine if requestContent_content_Basic_content_Basic_TopPanel should be set to null
            if (requestContent_content_Basic_content_Basic_TopPanelIsNull)
            {
                requestContent_content_Basic_content_Basic_TopPanel = null;
            }
            if (requestContent_content_Basic_content_Basic_TopPanel != null)
            {
                requestContent_content_Basic.TopPanel = requestContent_content_Basic_content_Basic_TopPanel;
                requestContent_content_BasicIsNull = false;
            }
             // determine if requestContent_content_Basic should be set to null
            if (requestContent_content_BasicIsNull)
            {
                requestContent_content_Basic = null;
            }
            if (requestContent_content_Basic != null)
            {
                request.Content.Basic = requestContent_content_Basic;
                requestContentIsNull = false;
            }
             // determine if request.Content should be set to null
            if (requestContentIsNull)
            {
                request.Content = null;
            }
            if (cmdletContext.DomainId != null)
            {
                request.DomainId = cmdletContext.DomainId;
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
        
        private Amazon.ConnectCases.Model.CreateLayoutResponse CallAWSServiceOperation(IAmazonConnectCases client, Amazon.ConnectCases.Model.CreateLayoutRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Cases", "CreateLayout");
            try
            {
                return client.CreateLayoutAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.ConnectCases.Model.Section> MoreInfo_Section { get; set; }
            public List<Amazon.ConnectCases.Model.Section> TopPanel_Section { get; set; }
            public System.String DomainId { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.ConnectCases.Model.CreateLayoutResponse, NewCCASLayoutCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}

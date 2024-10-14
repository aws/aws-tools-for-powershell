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
using Amazon.Kendra;
using Amazon.Kendra.Model;

namespace Amazon.PowerShell.Cmdlets.KNDR
{
    /// <summary>
    /// Updates a set of featured results. Features results are placed above all other results
    /// for certain queries. You map specific queries to specific documents for featuring
    /// in the results. If a query contains an exact match of a query, then one or more specific
    /// documents are featured in the search results.
    /// </summary>
    [Cmdlet("Update", "KNDRFeaturedResultsSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kendra.Model.FeaturedResultsSet")]
    [AWSCmdlet("Calls the Amazon Kendra UpdateFeaturedResultsSet API operation.", Operation = new[] {"UpdateFeaturedResultsSet"}, SelectReturnType = typeof(Amazon.Kendra.Model.UpdateFeaturedResultsSetResponse))]
    [AWSCmdletOutput("Amazon.Kendra.Model.FeaturedResultsSet or Amazon.Kendra.Model.UpdateFeaturedResultsSetResponse",
        "This cmdlet returns an Amazon.Kendra.Model.FeaturedResultsSet object.",
        "The service call response (type Amazon.Kendra.Model.UpdateFeaturedResultsSetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateKNDRFeaturedResultsSetCmdlet : AmazonKendraClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A new description for the set of featured results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FeaturedDocument
        /// <summary>
        /// <para>
        /// <para>A list of document IDs for the documents you want to feature at the top of the search
        /// results page. For more information on the list of featured documents, see <a href="https://docs.aws.amazon.com/kendra/latest/dg/API_FeaturedResultsSet.html">FeaturedResultsSet</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FeaturedDocuments")]
        public Amazon.Kendra.Model.FeaturedDocument[] FeaturedDocument { get; set; }
        #endregion
        
        #region Parameter FeaturedResultsSetId
        /// <summary>
        /// <para>
        /// <para>The identifier of the set of featured results that you want to update.</para>
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
        public System.String FeaturedResultsSetId { get; set; }
        #endregion
        
        #region Parameter FeaturedResultsSetName
        /// <summary>
        /// <para>
        /// <para>A new name for the set of featured results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FeaturedResultsSetName { get; set; }
        #endregion
        
        #region Parameter IndexId
        /// <summary>
        /// <para>
        /// <para>The identifier of the index used for featuring results.</para>
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
        public System.String IndexId { get; set; }
        #endregion
        
        #region Parameter QueryText
        /// <summary>
        /// <para>
        /// <para>A list of queries for featuring results. For more information on the list of queries,
        /// see <a href="https://docs.aws.amazon.com/kendra/latest/dg/API_FeaturedResultsSet.html">FeaturedResultsSet</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QueryTexts")]
        public System.String[] QueryText { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>You can set the status to <c>ACTIVE</c> or <c>INACTIVE</c>. When the value is <c>ACTIVE</c>,
        /// featured results are ready for use. You can still configure your settings before setting
        /// the status to <c>ACTIVE</c>. The queries you specify for featured results must be
        /// unique per featured results set for each index, whether the status is <c>ACTIVE</c>
        /// or <c>INACTIVE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Kendra.FeaturedResultsSetStatus")]
        public Amazon.Kendra.FeaturedResultsSetStatus Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FeaturedResultsSet'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kendra.Model.UpdateFeaturedResultsSetResponse).
        /// Specifying the name of a property of type Amazon.Kendra.Model.UpdateFeaturedResultsSetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FeaturedResultsSet";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FeaturedResultsSetId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FeaturedResultsSetId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FeaturedResultsSetId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FeaturedResultsSetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KNDRFeaturedResultsSet (UpdateFeaturedResultsSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kendra.Model.UpdateFeaturedResultsSetResponse, UpdateKNDRFeaturedResultsSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FeaturedResultsSetId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            if (this.FeaturedDocument != null)
            {
                context.FeaturedDocument = new List<Amazon.Kendra.Model.FeaturedDocument>(this.FeaturedDocument);
            }
            context.FeaturedResultsSetId = this.FeaturedResultsSetId;
            #if MODULAR
            if (this.FeaturedResultsSetId == null && ParameterWasBound(nameof(this.FeaturedResultsSetId)))
            {
                WriteWarning("You are passing $null as a value for parameter FeaturedResultsSetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FeaturedResultsSetName = this.FeaturedResultsSetName;
            context.IndexId = this.IndexId;
            #if MODULAR
            if (this.IndexId == null && ParameterWasBound(nameof(this.IndexId)))
            {
                WriteWarning("You are passing $null as a value for parameter IndexId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.QueryText != null)
            {
                context.QueryText = new List<System.String>(this.QueryText);
            }
            context.Status = this.Status;
            
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
            var request = new Amazon.Kendra.Model.UpdateFeaturedResultsSetRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FeaturedDocument != null)
            {
                request.FeaturedDocuments = cmdletContext.FeaturedDocument;
            }
            if (cmdletContext.FeaturedResultsSetId != null)
            {
                request.FeaturedResultsSetId = cmdletContext.FeaturedResultsSetId;
            }
            if (cmdletContext.FeaturedResultsSetName != null)
            {
                request.FeaturedResultsSetName = cmdletContext.FeaturedResultsSetName;
            }
            if (cmdletContext.IndexId != null)
            {
                request.IndexId = cmdletContext.IndexId;
            }
            if (cmdletContext.QueryText != null)
            {
                request.QueryTexts = cmdletContext.QueryText;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.Kendra.Model.UpdateFeaturedResultsSetResponse CallAWSServiceOperation(IAmazonKendra client, Amazon.Kendra.Model.UpdateFeaturedResultsSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kendra", "UpdateFeaturedResultsSet");
            try
            {
                #if DESKTOP
                return client.UpdateFeaturedResultsSet(request);
                #elif CORECLR
                return client.UpdateFeaturedResultsSetAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Kendra.Model.FeaturedDocument> FeaturedDocument { get; set; }
            public System.String FeaturedResultsSetId { get; set; }
            public System.String FeaturedResultsSetName { get; set; }
            public System.String IndexId { get; set; }
            public List<System.String> QueryText { get; set; }
            public Amazon.Kendra.FeaturedResultsSetStatus Status { get; set; }
            public System.Func<Amazon.Kendra.Model.UpdateFeaturedResultsSetResponse, UpdateKNDRFeaturedResultsSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FeaturedResultsSet;
        }
        
    }
}

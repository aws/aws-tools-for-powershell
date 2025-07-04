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
using Amazon.CustomerProfiles;
using Amazon.CustomerProfiles.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CPF
{
    /// <summary>
    /// Returns a list of objects associated with a profile of a given ProfileObjectType.
    /// </summary>
    [Cmdlet("Get", "CPFProfileObjectList")]
    [OutputType("Amazon.CustomerProfiles.Model.ListProfileObjectsItem")]
    [AWSCmdlet("Calls the Amazon Connect Customer Profiles ListProfileObjects API operation.", Operation = new[] {"ListProfileObjects"}, SelectReturnType = typeof(Amazon.CustomerProfiles.Model.ListProfileObjectsResponse))]
    [AWSCmdletOutput("Amazon.CustomerProfiles.Model.ListProfileObjectsItem or Amazon.CustomerProfiles.Model.ListProfileObjectsResponse",
        "This cmdlet returns a collection of Amazon.CustomerProfiles.Model.ListProfileObjectsItem objects.",
        "The service call response (type Amazon.CustomerProfiles.Model.ListProfileObjectsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCPFProfileObjectListCmdlet : AmazonCustomerProfilesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The unique name of the domain.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter ObjectFilter_KeyName
        /// <summary>
        /// <para>
        /// <para>A searchable identifier of a profile object. The predefined keys you can use to search
        /// for <c>_asset</c> include: <c>_assetId</c>, <c>_assetName</c>, and <c>_serialNumber</c>.
        /// The predefined keys you can use to search for <c>_case</c> include: <c>_caseId</c>.
        /// The predefined keys you can use to search for <c>_order</c> include: <c>_orderId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ObjectFilter_KeyName { get; set; }
        #endregion
        
        #region Parameter ObjectTypeName
        /// <summary>
        /// <para>
        /// <para>The name of the profile object type.</para>
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
        public System.String ObjectTypeName { get; set; }
        #endregion
        
        #region Parameter ProfileId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of a customer profile.</para>
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
        public System.String ProfileId { get; set; }
        #endregion
        
        #region Parameter ObjectFilter_Value
        /// <summary>
        /// <para>
        /// <para>A list of key values.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ObjectFilter_Values")]
        public System.String[] ObjectFilter_Value { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of objects returned per page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token from the previous call to ListProfileObjects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CustomerProfiles.Model.ListProfileObjectsResponse).
        /// Specifying the name of a property of type Amazon.CustomerProfiles.Model.ListProfileObjectsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CustomerProfiles.Model.ListProfileObjectsResponse, GetCPFProfileObjectListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ObjectFilter_KeyName = this.ObjectFilter_KeyName;
            if (this.ObjectFilter_Value != null)
            {
                context.ObjectFilter_Value = new List<System.String>(this.ObjectFilter_Value);
            }
            context.ObjectTypeName = this.ObjectTypeName;
            #if MODULAR
            if (this.ObjectTypeName == null && ParameterWasBound(nameof(this.ObjectTypeName)))
            {
                WriteWarning("You are passing $null as a value for parameter ObjectTypeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProfileId = this.ProfileId;
            #if MODULAR
            if (this.ProfileId == null && ParameterWasBound(nameof(this.ProfileId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProfileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CustomerProfiles.Model.ListProfileObjectsRequest();
            
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
             // populate ObjectFilter
            var requestObjectFilterIsNull = true;
            request.ObjectFilter = new Amazon.CustomerProfiles.Model.ObjectFilter();
            System.String requestObjectFilter_objectFilter_KeyName = null;
            if (cmdletContext.ObjectFilter_KeyName != null)
            {
                requestObjectFilter_objectFilter_KeyName = cmdletContext.ObjectFilter_KeyName;
            }
            if (requestObjectFilter_objectFilter_KeyName != null)
            {
                request.ObjectFilter.KeyName = requestObjectFilter_objectFilter_KeyName;
                requestObjectFilterIsNull = false;
            }
            List<System.String> requestObjectFilter_objectFilter_Value = null;
            if (cmdletContext.ObjectFilter_Value != null)
            {
                requestObjectFilter_objectFilter_Value = cmdletContext.ObjectFilter_Value;
            }
            if (requestObjectFilter_objectFilter_Value != null)
            {
                request.ObjectFilter.Values = requestObjectFilter_objectFilter_Value;
                requestObjectFilterIsNull = false;
            }
             // determine if request.ObjectFilter should be set to null
            if (requestObjectFilterIsNull)
            {
                request.ObjectFilter = null;
            }
            if (cmdletContext.ObjectTypeName != null)
            {
                request.ObjectTypeName = cmdletContext.ObjectTypeName;
            }
            if (cmdletContext.ProfileId != null)
            {
                request.ProfileId = cmdletContext.ProfileId;
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
        
        private Amazon.CustomerProfiles.Model.ListProfileObjectsResponse CallAWSServiceOperation(IAmazonCustomerProfiles client, Amazon.CustomerProfiles.Model.ListProfileObjectsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Customer Profiles", "ListProfileObjects");
            try
            {
                return client.ListProfileObjectsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DomainName { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ObjectFilter_KeyName { get; set; }
            public List<System.String> ObjectFilter_Value { get; set; }
            public System.String ObjectTypeName { get; set; }
            public System.String ProfileId { get; set; }
            public System.Func<Amazon.CustomerProfiles.Model.ListProfileObjectsResponse, GetCPFProfileObjectListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}

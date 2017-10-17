/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.WAFRegional;
using Amazon.WAFRegional.Model;

namespace Amazon.PowerShell.Cmdlets.WAFR
{
    /// <summary>
    /// Inserts or deletes <a>GeoMatchConstraint</a> objects in an <code>GeoMatchSet</code>.
    /// For each <code>GeoMatchConstraint</code> object, you specify the following values:
    /// 
    /// 
    ///  <ul><li><para>
    /// Whether to insert or delete the object from the array. If you want to change an <code>GeoMatchConstraint</code>
    /// object, you delete the existing object and add a new one.
    /// </para></li><li><para>
    /// The <code>Type</code>. The only valid value for <code>Type</code> is <code>Country</code>.
    /// </para></li><li><para>
    /// The <code>Value</code>, which is a two character code for the country to add to the
    /// <code>GeoMatchConstraint</code> object. Valid codes are listed in <a>GeoMatchConstraint$Value</a>.
    /// </para></li></ul><para>
    /// To create and configure an <code>GeoMatchSet</code>, perform the following steps:
    /// </para><ol><li><para>
    /// Submit a <a>CreateGeoMatchSet</a> request.
    /// </para></li><li><para>
    /// Use <a>GetChangeToken</a> to get the change token that you provide in the <code>ChangeToken</code>
    /// parameter of an <a>UpdateGeoMatchSet</a> request.
    /// </para></li><li><para>
    /// Submit an <code>UpdateGeoMatchSet</code> request to specify the country that you want
    /// AWS WAF to watch for.
    /// </para></li></ol><para>
    /// When you update an <code>GeoMatchSet</code>, you specify the country that you want
    /// to add and/or the country that you want to delete. If you want to change a country,
    /// you delete the existing country and add the new one.
    /// </para><para>
    /// For more information about how to use the AWS WAF API to allow or block HTTP requests,
    /// see the <a href="http://docs.aws.amazon.com/waf/latest/developerguide/">AWS WAF Developer
    /// Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "WAFRGeoMatchSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the UpdateGeoMatchSet operation against AWS WAF Regional.", Operation = new[] {"UpdateGeoMatchSet"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.WAFRegional.Model.UpdateGeoMatchSetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateWAFRGeoMatchSetCmdlet : AmazonWAFRegionalClientCmdlet, IExecutor
    {
        
        #region Parameter ChangeToken
        /// <summary>
        /// <para>
        /// <para>The value returned by the most recent call to <a>GetChangeToken</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ChangeToken { get; set; }
        #endregion
        
        #region Parameter GeoMatchSetId
        /// <summary>
        /// <para>
        /// <para>The <code>GeoMatchSetId</code> of the <a>GeoMatchSet</a> that you want to update.
        /// <code>GeoMatchSetId</code> is returned by <a>CreateGeoMatchSet</a> and by <a>ListGeoMatchSets</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String GeoMatchSetId { get; set; }
        #endregion
        
        #region Parameter Update
        /// <summary>
        /// <para>
        /// <para>An array of <code>GeoMatchSetUpdate</code> objects that you want to insert into or
        /// delete from an <a>GeoMatchSet</a>. For more information, see the applicable data types:</para><ul><li><para><a>GeoMatchSetUpdate</a>: Contains <code>Action</code> and <code>GeoMatchConstraint</code></para></li><li><para><a>GeoMatchConstraint</a>: Contains <code>Type</code> and <code>Value</code></para><para>You can have only one <code>Type</code> and <code>Value</code> per <code>GeoMatchConstraint</code>.
        /// To add multiple countries, include multiple <code>GeoMatchSetUpdate</code> objects
        /// in your request.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Updates")]
        public Amazon.WAFRegional.Model.GeoMatchSetUpdate[] Update { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("GeoMatchSetId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WAFRGeoMatchSet (UpdateGeoMatchSet)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ChangeToken = this.ChangeToken;
            context.GeoMatchSetId = this.GeoMatchSetId;
            if (this.Update != null)
            {
                context.Updates = new List<Amazon.WAFRegional.Model.GeoMatchSetUpdate>(this.Update);
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
            var request = new Amazon.WAFRegional.Model.UpdateGeoMatchSetRequest();
            
            if (cmdletContext.ChangeToken != null)
            {
                request.ChangeToken = cmdletContext.ChangeToken;
            }
            if (cmdletContext.GeoMatchSetId != null)
            {
                request.GeoMatchSetId = cmdletContext.GeoMatchSetId;
            }
            if (cmdletContext.Updates != null)
            {
                request.Updates = cmdletContext.Updates;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ChangeToken;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.WAFRegional.Model.UpdateGeoMatchSetResponse CallAWSServiceOperation(IAmazonWAFRegional client, Amazon.WAFRegional.Model.UpdateGeoMatchSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF Regional", "UpdateGeoMatchSet");
            try
            {
                #if DESKTOP
                return client.UpdateGeoMatchSet(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateGeoMatchSetAsync(request);
                return task.Result;
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
            public System.String ChangeToken { get; set; }
            public System.String GeoMatchSetId { get; set; }
            public List<Amazon.WAFRegional.Model.GeoMatchSetUpdate> Updates { get; set; }
        }
        
    }
}
